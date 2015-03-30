using System;
using System.Linq;
using _01.EF_Mappings;
using System.Web.Script.Serialization;

namespace _02.ExportLeaguesAndTeamsAsJson
{
    class ExportToJson
    {
        static void Main(string[] args)
        {
            var cx = new FootballEntities();

            var leagues = cx.Leagues
                .OrderBy(l => l.LeagueName)
                .Select(l => new
                {
                    Name = l.LeagueName,
                    Teams = l.Teams
                        .OrderBy(t => t.TeamName)
                        .Select(t => t.TeamName)
                })
                .ToList();

            foreach (var league in leagues)
            {
                Console.WriteLine("{0}: {1}", league.Name, String.Join(", ", league.Teams));
            }

            var jsSerializer = new JavaScriptSerializer();
            var riverJSON = jsSerializer.Serialize(leagues);
            Console.WriteLine();
            Console.WriteLine(riverJSON);

            System.IO.File.WriteAllText("leagues-and-teams.json", riverJSON);
            Console.WriteLine("\nExported to json");
        }
    }
}
