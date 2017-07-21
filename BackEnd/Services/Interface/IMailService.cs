using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace BackEnd.Services
{
    public interface IMailService
    {
        Task<HttpResponseMessage> sendMailAsync(string message);
    }
}