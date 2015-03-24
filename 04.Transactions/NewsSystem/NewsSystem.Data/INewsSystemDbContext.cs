using NewsSystem.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace NewsSystem.Data
{
    public interface INewsSystemDbContext
    {
        IDbSet<News> News { get; set; }
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        DbSet<T> Set<T>() where T : class;
        int SaveChanges();
    }
}
