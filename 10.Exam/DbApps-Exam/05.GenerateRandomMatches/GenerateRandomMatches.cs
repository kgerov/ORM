using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using _01.EF_Mappings;
using System.Xml;
using System.Globalization;

namespace _05.GenerateRandomMatches
{
    class GenerateRandomMatches
    {
        static Random rnd = new Random();

        static void Main(string[] args)
        {
            var cx = new FootballEntities();

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("../../generate-matches.xml");
            string xPathQuery = "/generate-random-matches/generate";

            XmlNodeList generateList = xmlDoc.SelectNodes(xPathQuery);

            int iter = 1;

            foreach (XmlNode generateNode in generateList)
            {
                Console.WriteLine("Processing request #{0} ...", iter);

                int generateCount = 10;
                int maxGoals = 5;
                string league = String.Empty;
                League leagueDb = null;
                DateTime startDate = new DateTime(2000, 1, 1);
                DateTime endDate = new DateTime(2015, 12, 31);

                if (generateNode.Attributes["generate-count"] != null)
                {
                    generateCount = Convert.ToInt32(generateNode.Attributes["generate-count"].InnerText);
                }

                if (generateNode.Attributes["max-goals"] != null)
                {
                    maxGoals = Convert.ToInt32(generateNode.Attributes["max-goals"].InnerText);
                }

                if (generateNode.SelectSingleNode("league") != null)
                {
                    league = generateNode.SelectSingleNode("league").InnerText;
                    leagueDb = cx.Leagues.FirstOrDefault(x => x.LeagueName == league);
                }

                if (generateNode.SelectSingleNode("start-date") != null)
                {
                    startDate = DateTime.Parse(generateNode.SelectSingleNode("start-date").InnerText);
                }

                if (generateNode.SelectSingleNode("end-date") != null)
                {
                    endDate = DateTime.Parse(generateNode.SelectSingleNode("end-date").InnerText);
                }

                //Console.WriteLine("{0}, {1}, {2}, {3} || {4}", generateCount, maxGoals, league, startDate, endDate);

                for (int i = 0; i < generateCount; i++)
                {
                    DateTime matchDate = getRandomDate(startDate, endDate);
                    
                    int team1Id = getRandomFirstTeam();
                    Team team1 = cx.Teams.FirstOrDefault(x => x.Id == team1Id);
                    int team2Id = getRandomSecondTeam(team1);
                    Team team2 = cx.Teams.FirstOrDefault(x => x.Id == team2Id);

                    int score1 = getRandomScore(maxGoals);
                    int score2 = getRandomScore(maxGoals);

                    TeamMatch newMatch = new TeamMatch()
                    {
                        League = leagueDb,
                        HomeGoals = score1,
                        AwayGoals = score2,
                        TeamHome = team1,
                        TeamAway = team2,
                        MatchDate = matchDate
                    };

                    cx.TeamMatches.Add(newMatch);

                    cx.SaveChanges();
                    printMatch(newMatch);
                }

                iter++;
                Console.WriteLine();
            }
        }

        public static DateTime getRandomDate(DateTime startDate, DateTime endDate)
        {
            TimeSpan timeSpan = endDate - startDate;
            TimeSpan newSpan = new TimeSpan(0, rnd.Next(0, (int)timeSpan.TotalMinutes), 0);
            DateTime newDate = startDate + newSpan;

            return newDate;
        }

        public static int getRandomScore(int max)
        {
            max++;
            int random = rnd.Next(0, max);

            return random;
        }

        public static int getRandomSecondTeam(Team invalid)
        {
            var cx = new FootballEntities();
            int chosenId = invalid.Id;
            var ids = cx.Teams.Select(t => t.Id).ToList();

            do
            {
                chosenId = rnd.Next(ids.Count);
            } while (invalid.Id == ids[chosenId]);

            return ids[chosenId];
        }

        public static int getRandomFirstTeam()
        {
            var cx = new FootballEntities();
            var ids = cx.Teams.Select(t => t.Id).ToList();
            int chosenId = rnd.Next(ids.Count);

            return ids[chosenId];
        }

        public static void printMatch(TeamMatch match)
        {
            CultureInfo culture = new CultureInfo("en-US");

            Console.WriteLine("{0}: {1} - {2}: {3}-{4} ({5})", DateTime.Parse(match.MatchDate.ToString()).ToString("dd-MMM-yyyy", culture),
                match.TeamHome.TeamName,
                match.TeamAway.TeamName,
                match.HomeGoals,
                match.AwayGoals,
                match.League == null ? "no league" : match.League.LeagueName);
        }
    }
}
