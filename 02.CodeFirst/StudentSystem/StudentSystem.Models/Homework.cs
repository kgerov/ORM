using System;
using System.Net.Mime;

namespace StudentSystem.Models
{
    public class Homework
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public decimal Grade { get; set; }

        public HomeworkType HomeworkType { get; set; }

        public DateTime SubmitDate { get; set; }

        public int StudentId { get; set; }

        public virtual Student Student { get; set; }

        public int CourseId { get; set; }

        public virtual Course Course { get; set; }
    }
}
