namespace _06.CodeFirstPhonebook
{
    using System.Data.Entity;
    using _06.CodeFirstPhonebook.Models;


    public class PhonebookContext : DbContext
    {
        public PhonebookContext()
            : base("name=PhonebookContext")
        {
        }

        public virtual DbSet<Contact> Contacts { get; set; }

        public virtual DbSet<Email> Emails { get; set; }

        public virtual DbSet<Phone> Phones { get; set; }
    }
}