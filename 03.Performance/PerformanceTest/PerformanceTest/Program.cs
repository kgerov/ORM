using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Data.Entity;

namespace PerformanceTest
{
    class Program
    {
        static void Main(string[] args)
        {
            AdsEntities cx = new AdsEntities();

            //Problem 1

            //foreach (var ad in cx.Ads)
            //{
            //    Console.WriteLine("{0} | {1}, {2}, {3}, {4}", ad.Title, ad.StatusId, ad.Category, ad.Town.Id, ad.AspNetUser);
            //    Console.WriteLine();
            //}

            //foreach (var ad in cx.Ads
            //    .Include(a => a.Category)
            //    .Include(a => a.Town)
            //    .Include(a => a.AspNetUser)
            //    .Include(a => a.AdStatus))
            //{
            //    Console.WriteLine("{0} | {1}, {2}, {3}, {4}", ad.Title, ad.StatusId, ad.Category, ad.Town, ad.AspNetUser);
            //    Console.WriteLine();
            //}


            //Problem 2

            //var ads = cx.Ads.ToList()
            //    .Where(a => a.AdStatus.Status == "Published")
            //    .Select(a => new
            //    {
            //        title = a.Title,
            //        category = a.Category == null ? "No Category" : a.Category.Name,
            //        town = a.Town == null ? "No Town" : a.Town.Name,
            //        date = a.Date
            //    })
            //    .ToList()
            //    .OrderBy(a => a.date);

            //foreach (var ad in ads)
            //{
            //    Console.WriteLine(ad.title + " | " + ad.category + " | " + ad.town);
            //}

            //var ads2 = cx.Ads
            //   .Where(a => a.AdStatus.Status == "Published")
            //   .Select(a => new
            //   {
            //       title = a.Title,
            //       category = a.Category == null ? "No Category" : a.Category.Name,
            //       town = a.Town == null ? "No Town" : a.Town.Name,
            //       date = a.Date
            //   })
            //   .OrderBy(a => a.date)
            //   .ToList();

            //foreach (var ad in ads2)
            //{
            //    Console.WriteLine(ad.title + " | " + ad.category + " | " + ad.town);
            //}

            
            //Problem 3

            //foreach (var s in cx.Ads)
            //{
            //    Console.WriteLine(s.Title);
            //}

            //foreach (var s in cx.Ads
            //  .Select(e => e.Title))
            //{
            //    Console.WriteLine(s);
            //}
        }
    }
}
