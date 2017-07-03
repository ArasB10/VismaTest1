using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace test1.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public int Age { get; set; }
        private Random rnd = new Random();
        private List<Contact> contacts;

        public List<Contact> GetContacts()
        {
            if (contacts == null)
            {
                contacts = new List<Contact> {
                    new Contact
                    {
                        Id = 1,
                        FirstName = "testF1",
                        LastName = "testL1",
                        Age = rnd.Next(1,45)
                    },

                    new Contact
                    {
                        Id = 2,
                        FirstName = "testF2",
                        LastName = "testL2",
                        Age = rnd.Next(1,45)
                    },

                    new Contact
                    {
                        Id = 3,
                        FirstName = "testF3",
                        LastName = "testL3",
                        Age = rnd.Next(1,45)
                    }
                };

                return contacts;
            }
            else
            {
                return contacts;
            } 
        }
    }
}