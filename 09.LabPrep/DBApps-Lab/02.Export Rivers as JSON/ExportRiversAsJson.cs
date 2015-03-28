using System;
using System.Linq;
using System.Web.Script.Serialization;
using EF_Mappings;

namespace _02.Export_Rivers_as_JSON
{
    class ExportRiversAsJson
    {
        static void Main(string[] args)
        {
            var cx = new GeographyEntities();

            var rivers = cx.Rivers
                .Select(x => 
                    new
                    {
                        Name = x.RiverName,
                        Length = x.Length,
                        Countries = x.Countries.Select(c => c.CountryName).OrderBy(c => c)
                    })
                    .OrderByDescending(x => x.Length)
                    .ToList();

            foreach (var river in rivers)
            {
                Console.WriteLine(river.Name + ": " + river.Length);
                Console.WriteLine("Countries: " + String.Join(", ", river.Countries.ToArray()));
                Console.WriteLine();
            }

            var jsSerializer = new JavaScriptSerializer();
            var riverJSON = jsSerializer.Serialize(rivers);
            Console.WriteLine(riverJSON);

            System.IO.File.WriteAllText("rivers.json", riverJSON);
        }
    }
}
