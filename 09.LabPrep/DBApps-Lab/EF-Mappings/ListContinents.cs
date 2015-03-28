using System;

namespace EF_Mappings
{
    class ListContinents
    {
        static void Main(string[] args)
        {
            var cx = new GeographyEntities();
            var continents = cx.Continents;

            foreach (var continent in continents)
            {
                Console.WriteLine(continent.ContinentName);   
            }
        }
    }
}
