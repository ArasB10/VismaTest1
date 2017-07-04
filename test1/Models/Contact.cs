using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace test1.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }

        [EmailAddress]
        public string Email { get; set; }
    }
}