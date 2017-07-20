using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackEnd.Services.Models
{
    public class Personalizations
    {
        public To[] To { get; set; }
        public string Subject { get; set; }
    }
}