using NewsSystem.Data;
using NewsSystem.Data.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsSystem.Models;

namespace NewsSystem.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<NewsSystemDbContext, Configuration>());
            var fcx = new NewsSystemDbContext();

            Console.WriteLine(fcx.News.FirstOrDefault().Content);

            while(true)
            {
                try
                {
                    var cx = new NewsSystemDbContext();
                    var firstNews = cx.News.FirstOrDefault();
                    Console.Write("Enter new value: ");
                    string input = Console.ReadLine();
                    firstNews.Content = input;
                    cx.SaveChanges();
                }
                catch (Exception)
                {
                    var newcx = new NewsSystemDbContext();
                    Console.Write("Conflict!");
                    Console.Write(newcx.News.FirstOrDefault().Content);
                    Console.WriteLine();
                    continue;
                }

                break;
            }

            Console.WriteLine("Changes successfully saved in the DB.");
        }
    }
}
