using System;
using System.Linq;
using _01.EF_Mappings;
using System.Text;
using System.Xml;
using System.Globalization;

namespace _03.ExportInternationalMatchesAsXML
{
    class ExportInternationalMatchesAsXML
    {
        static void Main(string[] args)
        {
            CultureInfo culture = new CultureInfo("en-US"); 
            var cx = new FootballEntities();

            var matches = cx.InternationalMatches
                .OrderBy(im => im.MatchDate)
                .ThenBy(im => im.HomeCountry)
                .ThenBy(im => im.AwayCountry)
                .Select(im => new
                {
                    League = im.League.LeagueName,
                    HomeCountry = im.HomeCountry.CountryName,
                    HomeCountryCode = im.HomeCountryCode,
                    AwayCountry = im.AwayCountry.CountryName,
                    AwayCountryCode = im.AwayCountryCode,
                    Date = im.MatchDate,
                    HomeScore = im.HomeGoals,
                    AwayScore = im.AwayGoals
                })
                .ToList();

            //foreach (var match in matches)
            //{
            //    Console.WriteLine("{0} - {1} \n {2} -- {3} \n {4} - {5}", match.League, match.Date, match.HomeCountry, match.AwayCountry, match.HomeScore, match.AwayScore);
            //    Console.WriteLine("=========================");
            //}

            string fileName = "international-matches.xml";
            Encoding encoding = Encoding.GetEncoding("windows-1251");
            using (XmlTextWriter writer = new XmlTextWriter(fileName, encoding))
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;

                writer.WriteStartDocument();
                writer.WriteStartElement("matches");

                foreach (var match in matches)
                {
                    writer.WriteStartElement("match");
                    if (match.Date != null)
                    {
                        if (DateTime.Parse(match.Date.ToString()).TimeOfDay.TotalSeconds == 0)
                        {
                            writer.WriteAttributeString("date", DateTime.Parse(match.Date.ToString()).ToString("dd-MMM-yyyy", culture));
                        }
                        else
                        {
                            writer.WriteAttributeString("date-time", DateTime.Parse(match.Date.ToString()).ToString("dd-MMM-yyyy hh:mm", culture));
                        }
                    }

                    writer.WriteStartElement("home-country");
                    writer.WriteAttributeString("code", match.HomeCountryCode);
                    writer.WriteString(match.HomeCountry);
                    writer.WriteEndElement();

                    writer.WriteStartElement("away-country");
                    writer.WriteAttributeString("code", match.AwayCountryCode);
                    writer.WriteString(match.AwayCountry);
                    writer.WriteEndElement();

                    if (match.League != null)
                    {
                        writer.WriteElementString("league", match.League);
                    }

                    if (match.HomeScore != null && match.AwayScore != null)
                    {
                        writer.WriteElementString("score", (match.HomeScore + "-" + match.AwayScore));
                    }

                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }
    }
}
