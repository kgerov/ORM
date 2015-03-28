using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF_Mappings;
using System.Xml;

namespace _03.Export_Monasteries_as_XML
{
    class ExportMonasteriesAsXml
    {
        static void Main(string[] args)
        {
            var cx = new GeographyEntities();

            var monasteries = cx.Countries
                .Where(c => c.Monasteries.Count > 0)
                .OrderBy(c => c.CountryName)
                .Select(c => new
                {
                    name = c.CountryName,
                    monasteries = c.Monasteries.OrderBy(m => m.Name).Select(m => m.Name)
                })
                .ToList();

            foreach (var monastery in monasteries)
            {
                Console.WriteLine(monastery.name + ": " + String.Join(", ", monastery.monasteries));
            }

            string fileName = "monasteries.xml";
            Encoding encoding = Encoding.GetEncoding("windows-1251");
            using (XmlTextWriter writer = new XmlTextWriter(fileName, encoding))
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;

                writer.WriteStartDocument();
                writer.WriteStartElement("monasteries");

                foreach (var monastery in monasteries)
                {
                    writer.WriteStartElement("country");
                    writer.WriteAttributeString("name", monastery.name);

                    foreach (var m in monastery.monasteries)
                    {
                        writer.WriteElementString("monastery", m);
                    }

                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }
    }
}
