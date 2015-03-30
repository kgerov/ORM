using _06.CodeFirstPhonebook.MigrationStrategy;
using System;
using System.Data.Entity;
using System.Linq;

namespace _06.CodeFirstPhonebook
{
    class CodeFirstPhonebook
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new PhonebookMigrationStrategy());

            var cx = new PhonebookContext();

            var contacts = cx.Contacts
                .Select(c => new
                {
                    Name = c.Name,
                    Phones = c.Phones.Select(p => p.Content),
                    Emails = c.Emails.Select(e => e.Content)
                })
                .ToList();

            foreach (var contact in contacts)
            {
                Console.WriteLine("{0}\n\tEmails: {1}\n\tPhones: {2}\n\n", contact.Name, String.Join(", ", contact.Emails), String.Join(", ", contact.Phones));
            }
        }
    }
}
