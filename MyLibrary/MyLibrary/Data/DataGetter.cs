using MyLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Data
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



        public Contact GetContact(int key)
        {

            //validate?

            return contacts[key];

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


        // if not found throws KeyNotFoundException
        public void Remove(int key)
        {
            if (contacts.ContainsKey(key))
            {
                contacts.Remove(key);
            }
            else
            {
                throw new KeyNotFoundException();
            }
            

        }


        
        public void Update(int key, Contact contact)
        {

            // validate contact
            if (contacts.ContainsKey(key))
            {
                contacts[id] = contact;
            }
            else
            {
                throw new KeyNotFoundException();
            }
            

        }


    }
}
