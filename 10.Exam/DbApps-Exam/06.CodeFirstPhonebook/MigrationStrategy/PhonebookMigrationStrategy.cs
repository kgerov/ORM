using System.Data.Entity;
using _06.CodeFirstPhonebook.Models;

namespace _06.CodeFirstPhonebook.MigrationStrategy
{
    public class PhonebookMigrationStrategy
        : DropCreateDatabaseIfModelChanges<PhonebookContext>
    {
        protected override void Seed(PhonebookContext context)
        {
            var petarPhoneOne = new Phone() { Content = "+359 2 22 22 22" };
            context.Phones.Add(petarPhoneOne);
            var petarPhoneTwo = new Phone() { Content = "+359 88 77 88 99" };
            context.Phones.Add(petarPhoneTwo);
            var mariaPhoneOne = new Phone() { Content = "+359 22 33 44 55" };
            context.Phones.Add(mariaPhoneOne);

            var petarEmailOne = new Email() { Content = "peter@gmail.com" };
            context.Emails.Add(petarEmailOne);
            var petarEmailTwo = new Email() { Content = "peter_ivanov@yahoo.com" };
            context.Emails.Add(petarEmailTwo);
            var angieEmailOne = new Email() { Content = "info@angiestanton.com" };
            context.Emails.Add(angieEmailOne);

            var petar = new Contact() { Name = "Petar Ivanov", Position = "CTO", Company = "Smart Ideas", Site = "http://blog.peter.com", Notes = "Friend from school" };
            petar.Phones.Add(petarPhoneOne);
            petar.Phones.Add(petarPhoneTwo);
            petar.Emails.Add(petarEmailOne);
            petar.Emails.Add(petarEmailTwo);
            context.Contacts.Add(petar);

            var maria = new Contact() {Name = "Maria"};
            maria.Phones.Add(mariaPhoneOne);
            context.Contacts.Add(maria);

            var angie = new Contact() { Name = "Angie Stanton", Site = "http://angiestanton.com" };
            angie.Emails.Add(angieEmailOne);
            context.Contacts.Add(angie);
        }
    }
}
