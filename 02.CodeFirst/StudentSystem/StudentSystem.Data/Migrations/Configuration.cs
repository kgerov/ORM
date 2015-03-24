using System.Collections.Generic;
using StudentSystem.Models;

namespace StudentSystem.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<StudentSystem.Data.StudentSystemDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            ContextKey = "StudentSystem.Data.StudentSystemDbContext";
        }

        protected override void Seed(StudentSystem.Data.StudentSystemDbContext context)
        {
            context.Students.Add(new Student
            {
                FirstName = "Gosheto",
                LastName = "Kiochek",
                BirdthdayDate = DateTime.Now.AddYears(-1),
                PhoneNumber = "+3458345093",
                RegistrationDate = DateTime.Now.AddDays(-10),
                ContactInfo = new ContactInfo {Facebook = "asdf", Twitter = "asdf"}
            });

            context.Students.Add(new Student
            {
                FirstName = "Pesho",
                LastName = "Petroc",
                BirdthdayDate = DateTime.Now.AddYears(-18),
                PhoneNumber = "+4234324",
                RegistrationDate = DateTime.Now.AddDays(-20),
                ContactInfo = new ContactInfo {Facebook = "aa123asdf", Twitter = "123asdf"}
            });

            context.Courses.Add(new Course
            {
                Name = "Java Basics",
                Description = "Malko java",
                StartDate = DateTime.Now.AddMonths(-10),
                EndDate = DateTime.Now,
                Price = 200m
            });

            base.Seed(context);
        }
    }
}
