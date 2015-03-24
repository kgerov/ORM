using StudentSystem.Models;

namespace StudentSystem.Data.Repositories
{
    public interface IStudentRepository : IRepository<Student>
    {
        Student GetStudentByName(string name);
    }
}
