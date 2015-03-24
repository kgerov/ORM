using System;
using System.Collections;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using StudentSystem.Data;
using StudentSystem.Data.Migrations;
using StudentSystem.Data.Repositories;
using StudentSystem.Models;
using System.Collections.Generic;

namespace StudentSystem.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentSystemDbContext, Configuration>());
            var db = new StudentSystemDbContext();
            var data = new StudentSystemData(db);

            var studentsWithHomeworks = data.Students.All()
                .Select(e => new
                {
                    Name = e.FirstName + " " + e.LastName,
                    Homeworks = (e.Homeworks.Select(eh => eh.Content)).ToList()
                });

            foreach (var student in studentsWithHomeworks)
            {
                Console.Write(student.Name + ": ");
                foreach (var homework in student.Homeworks)
                {
                    Console.Write(homework + " | ");
                }

                Console.WriteLine();
            }
        }
    }
}

//var studentRepository = new GenericRepository<Student>(db);

//studentRepository.All().FirstOrDefault().FirstName = "Jivko";

//studentRepository.SaveChanges();
//var student = studentRepository.All().FirstOrDefault();