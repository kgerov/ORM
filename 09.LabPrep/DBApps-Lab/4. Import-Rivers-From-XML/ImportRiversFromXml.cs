using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF_Mappings;
using System.Xml;

namespace _4.Import_Rivers_From_XML
{
    class ImportRiversFromXml
    {
        static void Main(string[] args)
        {
            var cx = new GeographyEntities();

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("../../rivers.xml");
            string xPathQuery = "/rivers/river";

            XmlNodeList riverList = xmlDoc.SelectNodes(xPathQuery);

            foreach (XmlNode riverNode in riverList)
            {
                string riverName = riverNode.SelectSingleNode("name").InnerText;
                int riverLength = Convert.ToInt32(riverNode.SelectSingleNode("length").InnerText);
                string riverOutflow = riverNode.SelectSingleNode("outflow").InnerText;

                int? drainageArea = null;
                if (riverNode.SelectSingleNode("drainage-area") != null)
                {
                    drainageArea = Convert.ToInt32(riverNode.SelectSingleNode("drainage-area").InnerText);
                }

                int? averageDischarge = null;
                if (riverNode.SelectSingleNode("average-discharge") != null)
                {
                    averageDischarge = Convert.ToInt32(riverNode.SelectSingleNode("average-discharge").InnerText);
                }

                XmlNodeList countries = riverNode.SelectNodes("countries/country");

                List<string> riverCountries = new List<string>();
                foreach (XmlNode country in countries)
                {
                    riverCountries.Add(country.InnerText);
                }

                Console.WriteLine("{0}: {1}, {2}, {3}, {4} | {5}", riverName, riverLength, riverOutflow, drainageArea, averageDischarge, String.Join(", ", riverCountries));

                River newRiver = new River
                {
                    RiverName = riverName,
                    Length = riverLength,
                    Outflow = riverOutflow,
                    DrainageArea = drainageArea,
                    AverageDischarge = averageDischarge
                };

                foreach (var riverCountry in riverCountries)
                {
                    var country = cx.Countries.Where(x => x.CountryName == riverCountry).FirstOrDefault();
                    newRiver.Countries.Add(country);
                }

                cx.Rivers.Add(newRiver);
                cx.SaveChanges();
            }
        }
    }
}
