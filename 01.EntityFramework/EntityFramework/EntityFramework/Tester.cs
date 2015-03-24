using System;
using System.Linq;

namespace EntityFramework
{
    class Tester
    {
        static void Main()
        {
            //DAOClassTest();
            //EmpAfter2002();
            //queryString();
            //EmpByDepAndMan("Production", "Jo Brown");
            //ConcurentChanges();
            //InsertNewProject();
            CallStoredProc();
        }

        private static void CallStoredProc()
        {
            SoftUniEntities cx = new SoftUniEntities();
            var projects = cx.usp_SelectProjectsByEmployees("Guy", "Gilbert");

            foreach (var project in projects)
            {
                Console.WriteLine(project.Name);
            }
        }

        private static void InsertNewProject()
        {
            SoftUniEntities cx = new SoftUniEntities();
            cx.usp_SelectProjectsByEmployees("Guy", "Gilbert");
            Project sharp = new Project
            {
                Name = "Vzemi toz name",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddYears(1)
            };

            cx.Projects.Add(sharp);
            cx.SaveChanges();
        }

        public static void DAOClassTest()
        {
            Employee alex = new Employee
            {
                FirstName = "Alex",
                LastName = "Cobalt",
                MiddleName = "M",
                JobTitle = "Spec Ops",
                DepartmentID = 3,
                HireDate = DateTime.Now,
                Salary = 12444,
                AddressID = 3,
                ManagerID = 45
            };

            var newId = DAO.InsertEmp(alex);

            DAO.UpdateEmp(newId, "FirstName", "Alexia");

            DAO.DeleteEmp(295);
        }

        public static void EmpAfter2002()
        {
            SoftUniEntities SoftUniDbContext = new SoftUniEntities();

            var employeeFromDb = SoftUniDbContext.Employees
                    .Where(e => e.Projects.Any(p => p.StartDate.Year == 2002));

            foreach (var item in employeeFromDb)
            {
                Console.Write(item.FirstName + ' ' + item.LastName + ": ");
                foreach (var pr in item.Projects)
                {
                    Console.Write(pr.Name + " - " + pr.StartDate.Year + ", ");
                }
                Console.WriteLine();
            }
        }

        public static void queryString()
        {
            SoftUniEntities SoftUniDbContext = new SoftUniEntities();

            string query =
                @"SELECT DISTINCT FirstName + ' ' + LastName as [FullName]
                FROM Employees e
                JOIN EmployeesProjects ep
                ON ep.EmployeeId = e.EmployeeID
                WHERE ep.ProjectId IN 
		                (SELECT p.ProjectID
		                FROM Projects p
		                WHERE YEAR(p.StartDate) = '2002')";

            var employees = SoftUniDbContext.Database.SqlQuery<string>(query);

            foreach (var emp in employees)
            {
                Console.WriteLine(emp);
            }

        }

        public static void EmpByDepAndMan(string Dep, string Man)
        {
            SoftUniEntities SoftUniDbContect = new SoftUniEntities();

            var employees = SoftUniDbContect.Employees
                    .Where(x => ((x.Employee1.FirstName + " " + x.Employee1.LastName) == Man) &&
                                x.Department.Name == Dep);

            foreach (var emp in employees)
            {
                Console.WriteLine(emp.FirstName);
            }
        }

        public static void ConcurentChanges()
        { 
            SoftUniEntities SoftUniDbContext = new SoftUniEntities();
            SoftUniEntities SoftUniDbContext2 = new SoftUniEntities();

            Employee emp = SoftUniDbContext.Employees.FirstOrDefault(x => x.EmployeeID == 13);
            emp.GetType().GetProperty("FirstName").SetValue(emp, "Chuck");

            Employee emp2 = SoftUniDbContext2.Employees.FirstOrDefault(x => x.EmployeeID == 13);
            emp2.GetType().GetProperty("FirstName").SetValue(emp, "Sarah");

            SoftUniDbContext.SaveChanges();
            SoftUniDbContext2.SaveChanges();
        }
    }
}