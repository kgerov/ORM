using System.Linq;

namespace EntityFramework
{
    public static class DAO
    {
        private static SoftUniEntities SoftUniDbContext = new SoftUniEntities();
        public static int InsertEmp (Employee newEmp) 
        {
            SoftUniDbContext.Employees.Add(newEmp);
            SoftUniDbContext.SaveChanges();

            return newEmp.EmployeeID;
        }

        public static void UpdateEmp(int empId, string prop, object NewValue) 
        {
            Employee emp = getEmployeeById(empId);

            if (emp != null)
            {
                emp.GetType().GetProperty(prop).SetValue(emp, NewValue);
                SoftUniDbContext.SaveChanges();
            }
        }

        public static void DeleteEmp(int empId)
        {
            Employee emp = getEmployeeById(empId);
            SoftUniDbContext.Employees.Remove(emp);
            SoftUniDbContext.SaveChanges();
        }

        public static Employee getEmployeeById(int empId) 
        {
            Employee emp = SoftUniDbContext.Employees.FirstOrDefault(x => x.EmployeeID == empId);

            return emp;
        }
    }
}
