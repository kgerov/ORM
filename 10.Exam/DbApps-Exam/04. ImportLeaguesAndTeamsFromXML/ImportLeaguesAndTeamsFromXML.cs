using System;
using System.Linq;
using _01.EF_Mappings;
using System.Xml;

namespace _04.ImportLeaguesAndTeamsFromXML
{
    class ImportLeaguesAndTeamsFromXML
    {
        static void Main(string[] args)
        {
            var cx = new FootballEntities();
            
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("../../leagues-and-teams.xml");
            string xPathQuery = "/leagues-and-teams/league";

            XmlNodeList leagueList = xmlDoc.SelectNodes(xPathQuery);

            int iter = 1;

            foreach (XmlNode leagueNode in leagueList)
            {
                Console.WriteLine("Processing league #{0} ...", iter);
                string leagueName = String.Empty;

                if (leagueNode.SelectSingleNode("league-name") != null)
                {
                    leagueName = leagueNode.SelectSingleNode("league-name").InnerText;
                }

                var leagueDb = cx.Leagues.FirstOrDefault(x => x.LeagueName == leagueName);

                if (leagueName != String.Empty)
                {
                    if (leagueDb == null)
                    {
                        cx.Leagues.Add(new League()
                        {
                            LeagueName = leagueName
                        });

                        cx.SaveChanges();
                        Console.WriteLine("Created league: {0}", leagueName);
                    }
                    else
                    {
                        Console.WriteLine("Existing league: {0}", leagueName);
                    }
                }

                XmlNodeList teams = leagueNode.SelectNodes("teams/team");

                foreach (XmlNode team in teams)
                {
                    string teamName = team.Attributes["name"].InnerText;
                    string countryName = String.Empty;
                    Team teamDb = null;

                    if (team.Attributes["country"] != null)
                    {
                        countryName = team.Attributes["country"].InnerText;
                        teamDb =
                            cx.Teams.FirstOrDefault(x => x.TeamName == teamName && x.Country.CountryName == countryName);
                    }
                    else
                    {
                        teamDb =
                            cx.Teams.FirstOrDefault(x => x.TeamName == teamName && x.Country.CountryName == null);
                    }

                    if (teamDb == null)
                    {
                        Country countryDb = null;

                        if (countryName != String.Empty)
                        {
                            countryDb = cx.Countries.FirstOrDefault(x => x.CountryName == countryName);

                            cx.Teams.Add(new Team()
                            {
                                TeamName = teamName,
                                Country = countryDb
                            });

                            cx.SaveChanges();
                            Console.WriteLine("Created team: {0} ({1})", teamName, countryName);
                        }
                        else
                        {
                            cx.Teams.Add(new Team()
                            {
                                TeamName = teamName
                            });

                            cx.SaveChanges();
                            Console.WriteLine("Created team: {0} ({1})", teamName, "no country");
                        }
                    }
                    else
                    {
                        if (teamDb.Country == null)
                        {
                            Console.WriteLine("Existing team: {0} ({1})", teamDb.TeamName, "no country");
                        }
                        else
                        {
                            Console.WriteLine("Existing team: {0} ({1})", teamDb.TeamName, teamDb.Country.CountryName);
                        }
                    }

                    if (leagueName != String.Empty)
                    {
                        leagueDb = cx.Leagues.FirstOrDefault(x => x.LeagueName == leagueName);

                        if (countryName != String.Empty)
                        {
                            teamDb =
                                cx.Teams.FirstOrDefault(
                                    x => x.TeamName == teamName && x.Country.CountryName == countryName);
                        }
                        else
                        {
                            teamDb = cx.Teams.FirstOrDefault(x => x.TeamName == teamName);
                        }

                        if (!leagueDb.Teams.Contains(teamDb))
                        {
                            leagueDb.Teams.Add(teamDb);
                            cx.SaveChanges();
                            Console.WriteLine("Added team to league: {0} to league {1}", teamName, leagueName);
                        }
                        else
                        {
                            Console.WriteLine("Existing team in league: {0} belongs to {1}", teamName, leagueName);
                        }
                    }
                }

                iter++;
                Console.WriteLine();
            }
        }
    }
}
