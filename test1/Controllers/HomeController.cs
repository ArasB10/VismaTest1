using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test1.Models;

namespace test1.Controllers
{
    public class HomeController : Controller
    {

        private Contact contact = new Contact();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Name(int id, string typeSet)
        {
            /*

            Contact contact = new Contact() {
                FirstName = "Aras",
                LastName = "Braziunas",
                Age = 23,
            };
            */
            
            List<Contact> list = contact.GetContacts();

            if (typeSet.Equals("up"))
            {
                return Content(list.Where(item => item.Id == id).First().FirstName.ToString().ToUpper());
            }
            else
            {
                return Content(list.Where(item => item.Id == id).First().FirstName.ToString().ToLower());
            }
        }

        public ActionResult Age(int id)
        {
           
            List<Contact> list = contact.GetContacts();

            return View(list.Where(item => item.Id == id).First());
        }

        public ActionResult List()
        {
            /*

            Contact contact = new Contact() {
                FirstName = "Aras",
                LastName = "Braziunas",
                Age = 23,
            };
            */
           
            List<Contact> list = contact.GetContacts();

            return View(list);
        }

        public ActionResult Details(int id)
        {
           
            List<Contact> list = contact.GetContacts();

            return View(list.Where(item => item.Id == id).First());
        }
    }
}