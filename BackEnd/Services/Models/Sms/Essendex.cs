using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackEnd.Services.Models
{
    public class Essendex
    {
        public string accountreference { get; set; }
        public Message[] messages { get; set; }
    }
}