﻿using BackEnd.Services.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;

namespace BackEnd.Services
{
    public class MailService : IMailService
    {

        static HttpClient client = new HttpClient();


        //public void sendMail(string message)
        //{
        //    var T = Task.Run(async () => await sendMailAsync(message));
        //    var a = T.Result;
        //}

        public async Task<HttpResponseMessage> sendMailAsync(String message)
        {

            SendGridMail model = new SendGridMail
            {
                Personalizations = new Personalizations[]
                {
                    new Personalizations
                    {
                        To = new To[]
                        {
                            new To
                            {
                                Email = "arasbraziunas10@gmail.com"
                            }
                        },
                        Subject = "Test mailer"  
                    }
                },
                From = new From
                {
                    Email = "vism2017@example.com"
                },
                Content = new Content[]
                {
                    new Content
                    {
                        type = "text/plain",
                        value = message
                    }
                }
                
            };


            //    messages = new Message[]
            //{
            //        new Message
            //        {
            //            to = "37062178248",
            //            body = message
            //        }
            //}
            //};


            client.DefaultRequestHeaders.Add("Authorization", "Bearer "+ WebConfigurationManager.AppSettings["emailKey"]);
            StringContent content = new StringContent(JsonConvert.SerializeObject(model));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "https://api.sendgrid.com/v3/mail/send");
            request.Content = content;
            var response = await client.SendAsync(request);

            return response;

        }
    }
}