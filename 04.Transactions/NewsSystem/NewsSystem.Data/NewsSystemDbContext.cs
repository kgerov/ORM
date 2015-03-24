using NewsSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsSystem.Data
{
    public class NewsSystemDbContext : DbContext, INewsSystemDbContext
    {
        public NewsSystemDbContext()
            : base("NewsSystem")
        {
            
        }

        public IDbSet<News> News { get; set; }

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
