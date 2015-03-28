using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.Mountains_Code_First
{
    class MountainsCodeFirst
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new MountainsMigrationStrategy());
            var cx = new MountainsContext();

            var countries = cx.Countries
                .Select(c => new
                {
                    Name = c.Name,
                    Peaks = (c.Mountains.SelectMany(m => m.Peaks)).Select(p => p.Name)
                })
                .ToList();

            foreach (var country in countries)
            {
                Console.WriteLine(country.Name + ": " + String.Join(", ", country.Peaks.ToArray()));
            }
        }
    }
}
