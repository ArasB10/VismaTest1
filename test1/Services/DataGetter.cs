using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using test1.Models;

namespace test1.Services
{
    public class DataGetter : IDataGetter
    {
        private Dictionary<int, Contact> contacts;

        private int id = 0;

        public DataGetter()
        {
            contacts = new Dictionary<int, Contact>();

            AddContact(new Contact() { FirstName = "Jonas", LastName = "Motiejauskas", Email = "jonas.motiejauskas@gmail.com" });

            AddContact(new Contact() { FirstName = "Benas", LastName = "Orlovas" });

            AddContact(new Contact() { FirstName = "Povilas", LastName = "Zvirblis", Phone = "+37062959639" });
        }

        public Contact GetContact(int id)

        {

            return contacts[id];

        }



        public IDictionary<int, Contact> GetContacts()

        {

            return contacts;

        }

        public Contact AddContact(Contact contact)

        {

            // validate contact

            contact.Id = id;

            contacts.Add(id, contact);

            id += 1;

            return contact;

        }


    }
}