using System;

namespace _01.EF_Mappings
{
    class EFMappings
    {
        static void Main(string[] args)
        {
            var cx = new FootballEntities();

            var teams = cx.Teams;

            foreach (var team in teams)
            {
                Console.WriteLine(team.TeamName);
            }
        }
    }
}
