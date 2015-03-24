using System;
using System.Collections;
using StudentSystem.Data.Repositories;
using System.Collections.Generic;
using StudentSystem.Models;
namespace StudentSystem.Data
{
    public class StudentSystemData : IStudentSystemData
    {
        private IStudentSystemDbContext context;
        private IDictionary<Type, object> repositories;

        public StudentSystemData(IStudentSystemDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }
        public IStudentRepository Students
        {
            get { return (IStudentRepository)this.GetRepository<Student>(); }
        }

        public IRepository<Course> Courses
        {
            get { return this.GetRepository<Course>(); }
        }

        public IRepository<Resourse> Resourses
        {
            get { return this.GetRepository<Resourse>(); }
        }

        public IRepository<Homework> Homeworks
        {
            get { return this.GetRepository<Homework>(); }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        public IRepository<T> GetRepository<T>() where T : class
        {
            var type = typeof(T);

            if (!this.repositories.ContainsKey(type))
            {
                var repositoryType = typeof(GenericRepository<T>);
                if (type.IsAssignableFrom(typeof(Student)))
                {
                    repositoryType = typeof(StudentRepository);
                }

                this.repositories.Add(type, Activator.CreateInstance(repositoryType, this.context));
            }

            return (IRepository<T>)this.repositories[type];
        }
    }
}
