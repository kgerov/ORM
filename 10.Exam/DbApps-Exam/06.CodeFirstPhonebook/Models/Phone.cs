﻿namespace _06.CodeFirstPhonebook.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Phone
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }

        public virtual Contact Contact { get; set; }
    }
}