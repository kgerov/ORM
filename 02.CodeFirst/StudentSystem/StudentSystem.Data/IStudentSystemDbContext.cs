using StudentSystem.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
namespace StudentSystem.Data
{
    public interface IStudentSystemDbContext
    {
        IDbSet<Student> Students { get; set; }

        IDbSet<Course> Courses { get; set; }

        IDbSet<Resourse> Resourses { get; set; }

        IDbSet<Homework> Homeworks { get; set; }
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        DbSet<T> Set<T>() where T : class;
        int SaveChanges();
    }
}
