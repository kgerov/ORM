using System;
using System.Data.Entity;
using StudentSystem.Models;

namespace StudentSystem.Data
{
    public class StudentSystemDbContext  : DbContext, IStudentSystemDbContext
    {
        public StudentSystemDbContext()
            : base("StudentSystem")
        {
            
        }
        public IDbSet<Student> Students { get; set; }

        public IDbSet<Course> Courses { get; set; }

        public IDbSet<Resourse> Resourses { get; set; }

        public IDbSet<Homework> Homeworks { get; set; }

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
