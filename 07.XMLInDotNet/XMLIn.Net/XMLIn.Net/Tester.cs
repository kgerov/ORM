using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace XMLIn.Net
{
    class Tester
    {
        static void Main(string[] args)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("../../catalog.xml");
            string xPathQuery = "/catalog/album/name";

            XmlNodeList nameList = xmlDoc.SelectNodes(xPathQuery);

            Console.WriteLine("01. Album Names\n");
            foreach (XmlNode albumNode in nameList)
            {
                string albumName = albumNode.InnerText;
                Console.WriteLine(albumName);
            }
            Console.WriteLine("======================");

            Console.WriteLine("02. Artists\n");
            HashSet<string> artists = new HashSet<string>();
            xPathQuery = "/catalog/album/artist";
            XmlNodeList artistList = xmlDoc.SelectNodes(xPathQuery);

            foreach (XmlNode artistNode in artistList)
            {
                string artist = artistNode.InnerText;
                artists.Add(artist);
            }

            IEnumerable<string> queryArtists = artists.OrderBy(x => x.ToString());

            foreach (var artist in queryArtists)
            {
                Console.WriteLine(artist);
            }
            Console.WriteLine("======================");

            Console.WriteLine("03. Artists and number of albums\n");
            Dictionary<string, int> artistAlbums = new Dictionary<string, int>();
            xPathQuery = "/catalog/album";
            XmlNodeList albumList = xmlDoc.SelectNodes(xPathQuery);

            foreach (XmlNode albumnNode in albumList)
            {
                string artist = albumnNode.SelectSingleNode("artist").InnerText.ToString();
                if (artistAlbums.ContainsKey(artist))
                {
                    artistAlbums[artist]++;
                }
                else
                {
                    artistAlbums.Add(artist, 1);
                }
            }

            foreach (KeyValuePair<string, int> artist in artistAlbums)
            {
                Console.WriteLine(artist.Key + ": " + artist.Value);
            }
            Console.WriteLine("======================");

            //Console.WriteLine("04. Remove\n");

            //foreach (XmlNode albumnNode in albumList)
            //{
            //    double price = Convert.ToDouble(albumnNode.SelectSingleNode("price").InnerText);

            //    if (price > 20)
            //    {
            //        albumnNode.ParentNode.RemoveChild(albumnNode);
            //    }
            //}

            //xmlDoc.Save("cheap-catalog.xml");
            //Console.WriteLine("======================");

            Console.WriteLine("05. Old albums\n");
            Dictionary<string, double> albumPrice = new Dictionary<string, double>();

            foreach (XmlNode albumnNode in albumList)
            {
                DateTime date = Convert.ToDateTime(albumnNode.SelectSingleNode("year").InnerText);
                if (DateTime.Now.AddYears(-5).Year >= date.Year)
                {
                    albumPrice.Add(albumnNode.SelectSingleNode("name").InnerText, Convert.ToDouble(albumnNode.SelectSingleNode("price").InnerText));
                }
            }

            foreach (KeyValuePair<string, double> entry in albumPrice)
            {
                Console.WriteLine(entry.Key + ": " + entry.Value + "$");
            }

            Console.WriteLine("======================");


            Console.WriteLine("06. Old albums LINQ\n");
            XDocument xDoc = XDocument.Load("../../catalog.xml");

            var albums =
                from album in xDoc.Descendants("album")
                where Convert.ToDateTime(album.Element("year").Value).Year <= DateTime.Now.AddYears(-5).Year
                select new
                {
                    name = album.Element("name").Value,
                    price = album.Element("price").Value
                };

            foreach (var album in albums)
            {
                Console.WriteLine("{0} (by {1})", album.name, album.price);
            }

            Console.WriteLine("======================");


        }
    }
}
