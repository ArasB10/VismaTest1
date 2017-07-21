using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace BackEnd.Services
{
    public class FailService : IMailService
    {
        public async Task<HttpResponseMessage> sendMailAsync(string message)
        {
            System.IO.File.AppendAllText(@"C:\logs\Messages.txt", Environment.NewLine + message);

            return await Task<HttpResponseMessage>.Factory.StartNew(() =>
            {
                return new HttpResponseMessage(HttpStatusCode.OK);
            });
        }
    }
}