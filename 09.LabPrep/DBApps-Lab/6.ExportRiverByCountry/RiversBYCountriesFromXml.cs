using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF_Mappings;
using System.Xml;

namespace _6.ExportRiverByCountry
{
    class RiversBYCountriesFromXml
    {
        static void Main(string[] args)
        {
            var cx = new GeographyEntities();

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("../../queries.xml");
            string xPathQuery = "/queries/query";

            XmlNodeList queryList = xmlDoc.SelectNodes(xPathQuery);

            foreach (XmlNode queryNode in queryList)
            {
                int a = Int32.MaxValue;
                if (queryNode.Attributes["max-results"] != null)
                {
                    a = Convert.ToInt32(queryNode.Attributes["max-results"].InnerText);
                }

                XmlNodeList countriesXml = queryNode.SelectNodes("country");
                List<string> countries = new List<string>();

                foreach (XmlNode country in countriesXml)
                {
                    countries.Add(country.InnerText);
                }

                var rivers = cx.Rivers
                    .Where(r => countries.All(cName => r.Countries.Any(cr => cr.CountryName == cName)))
                    .OrderBy(r => r.RiverName)
                    .Select(r => r.RiverName)
                    .ToList();

                foreach (var river in rivers)
                {
                    Console.WriteLine(river);
                }
                Console.WriteLine();
            }

            //string[] countriesNames = { "Romania", "Bulgaria", "Austria" };

            //var rivers = cx.Rivers
            //             .Where(r => countriesNames.All(name => r.Countries.Any(c => c.CountryName == name)))
            //             .ToList();

            //foreach (var river in rivers)
            //{
            //    Console.WriteLine(river.RiverName);
            //}
        }
    }
}
