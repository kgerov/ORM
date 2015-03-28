using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.Mountains_Code_First
{
    public class MountainsContext : DbContext
    {
        public MountainsContext()
            : base("MountainsContext")
        {

        }
        public virtual IDbSet<Country> Countries { get; set; }

        public virtual IDbSet<Mountain> Mountains{ get; set; }

        public virtual IDbSet<Peak> Peaks { get; set; }

        public IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
