using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackEnd.Services.Models
{
    public class SendGridMail
    {
        public Personalizations[] Personalizations { get; set; }
        public From From { get; set; }
        public Content[] Content { get; set; }
    }
}