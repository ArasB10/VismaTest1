using BackEnd.Services.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BackEnd.Services
{
    public class SmsService
    {
        static HttpClient client = new HttpClient();


        public void sendSms(String message)
        {
            var T = Task.Run(async()=> await sendSmsAsync(message));
            var a = T.Result;
        }

        public static async Task<HttpResponseMessage> sendSmsAsync(string message)
        {

            Essendex model = new Essendex
            {
                accountreference = "EX0235294",
                messages = new Message[]
            {
                    new Message
                    {
                        to = "37062178248",
                        body = message
                    }
            }
            };


            client.DefaultRequestHeaders.Add("Authorization", "Basic TGF1cmEuS3V0b3ZhamFAZ21haWwuY29tOnBhdGlraW1hc3NsYXB0YXpvZGlz");
            StringContent content = new StringContent(JsonConvert.SerializeObject(model));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "https://api.esendex.com/v1.0/messagedispatcher");
            request.Content = content;
            var response = await client.SendAsync(request);

            return response;



            //var formData = new List<KeyValuePair<string, string>>();
            //formData.Add(new KeyValuePair<string, string>("grant_type", "password"));
            //formData.Add(new KeyValuePair<string, string>("username", "<email>"));
            //formData.Add(new KeyValuePair<string, string>("password", "<password>"));
            //formData.Add(new KeyValuePair<string, string>("scope", "all"));

            //request.Content = new FormUrlEncodedContent(formData);
            //var response = client.SendAsync(request);



            //var client = new RestClient("https://api.esendex.com/v1.0/messagedispatcher");
            //var request = new RestRequest(Method.POST);
            ////request.AddHeader("postman-token", "6fe2d177-2481-5b4b-34e1-9d8cfee3b383");
            ////request.AddHeader("cache-control", "no-cache");
            //request.AddHeader("authorization", "Basic YXJhc2JyYXppdW5hczEwQGdtYWlsLmNvbTpwcmFrdGlrYTIwMTc=");
            //request.AddHeader("content-type", "application/json");
            //request.AddParameter("application/json", "{\r\n  \"accountreference\":\"EX0235305\",\r\n  \"messages\":[{\r\n    \"to\":\"37062959639\",\r\n    \"body\":\"Every!\"\r\n  }]\r\n}", ParameterType.RequestBody);
            //IRestResponse response = client.Execute(request);
        }
    }
}