using System;
using System.Linq;
using Newtonsoft.Json.Linq;
using _06.CodeFirstPhonebook;
using System.IO;
using _06.CodeFirstPhonebook.Models;

namespace _07.ImportContactsFromJSON
{
    class ImportContactsFromJSON
    {
        static void Main(string[] args)
        {
            string contactsJson = File.ReadAllText("../../contacts.json");
            var contacts = JArray.Parse(contactsJson);

            foreach (var contact in contacts)
            {
                try
                {
                    ImportContact(contact);
                    Console.WriteLine("Contact {0} imported", contact["name"]);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }

        private static void ImportContact(JToken contactObj)
        {
            var context = new PhonebookContext();
            var contact = new Contact();

            // Parse name
            if (contactObj["name"] == null)
            {
                throw new Exception("Name is required");
            }

            contact.Name = contactObj["name"].Value<string>();

            // Parse phones
            var phones = contactObj["phones"];
            if (phones != null)
            {
                foreach (var phone in phones)
                {
                    string phoneStr = phone.ToString();
                    var newPhone = new Phone() {Content = phone.ToString()};
                    context.Phones.Add(newPhone);
                    contact.Phones.Add(newPhone);
                }
            }

            // Parse emails
            var emails = contactObj["emails"];
            if (emails != null)
            {
                foreach (var email in emails)
                {
                    string emailStr = email.ToString();
                    var newEmail = new Email() {Content = email.ToString()};
                    context.Emails.Add(newEmail);
                    contact.Emails.Add(newEmail);
                }
            }

            //Parse position
            if (contactObj["position"] != null)
            {
                contact.Position = contactObj["position"].Value<string>();
            }

            //Parse site
            if (contactObj["site"] != null)
            {
                contact.Site = contactObj["site"].Value<string>();
            }

            //Parse notes
            if (contactObj["notes"] != null)
            {
                contact.Notes = contactObj["notes"].Value<string>();
            }

            //Parse company
            if (contactObj["company"] != null)
            {
                contact.Company = contactObj["company"].Value<string>();
            }


            context.Contacts.Add(contact);
            context.SaveChanges();
        }
    }
}
