using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.Mountains_Code_First
{
    public class MountainsMigrationStrategy
        : DropCreateDatabaseIfModelChanges<MountainsContext>
    {
        protected override void Seed(MountainsContext context)
        {
            var bulgaria = new Country() { Code = "BG", Name = "Bulgaria"};
            context.Countries.Add(bulgaria);
            var germany = new Country() {Code = "DE", Name = "Germany"};
            context.Countries.Add(germany);

            var rila = new Mountain() {Name = "Rila", Countries = {bulgaria}};
            context.Mountains.Add(rila);
            var pirin = new Mountain() { Name = "Pirin", Countries = { bulgaria } };
            context.Mountains.Add(pirin );
            var rhodopes = new Mountain() { Name = "Rodopi", Countries = { bulgaria } };
            context.Mountains.Add(rhodopes);

            var musala = new Peak() {Name = "Musala", Elevation = 32432, Mountain = rila};
            context.Peaks.Add(musala);
            var mal = new Peak() { Name = "Malyovitsa", Elevation = 123, Mountain = rila };
            context.Peaks.Add(mal);
            var vihren = new Peak() { Name = "Vihren", Elevation = 11, Mountain = pirin };
            context.Peaks.Add(vihren);
        }
    }
}
