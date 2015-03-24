using StudentSystem.Data.Repositories;
using StudentSystem.Models;
namespace StudentSystem.Data
{
    public interface IStudentSystemData
    {
        IStudentRepository Students { get; }
        IRepository<Course> Courses { get; }
        IRepository<Resourse> Resourses { get; }
        IRepository<Homework> Homeworks { get; }
    }
}
