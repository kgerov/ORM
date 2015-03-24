using System.Collections;
using System.Collections.Generic;

namespace StudentSystem.Models
{
    public class Resourse
    {
        private ICollection<Course> courses;

        public Resourse()
        {
            this.courses = new HashSet<Course>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public ResourseType ResourseType { get; set; }

        public string Link { get; set; }

        public virtual ICollection<Course> Courses
        {
            get { return this.courses; }
            set { this.courses = value; }
        }
    }
}
