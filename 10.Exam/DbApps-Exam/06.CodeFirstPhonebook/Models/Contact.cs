namespace _06.CodeFirstPhonebook.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;

    public class Contact
    {
        private ICollection<Phone> phones;
        private ICollection<Email> emails;

        public Contact()
        {
            this.phones = new List<Phone>();
            this.emails = new List<Email>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Phone> Phones
        {
            get { return this.phones; }
            set { this.phones = value; }
        }

        public ICollection<Email> Emails
        {
            get { return this.emails; }
            set { this.emails = value; }
        }

        public string Position { get; set; }

        public string Company { get; set; }

        public string Site { get; set; }

        [Column(TypeName = "text")]
        public string Notes { get; set; }
    }
}
