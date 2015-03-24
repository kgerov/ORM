using System.Linq;
using StudentSystem.Models;
namespace StudentSystem.Data.Repositories
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        public StudentRepository(IStudentSystemDbContext context)
            : base(context)
        {
            
        }
        public Student GetStudentByName(string name)
        {
            return this.All().FirstOrDefault(x => x.FirstName == name);
        }
    }
}
