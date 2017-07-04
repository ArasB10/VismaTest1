using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test1.Models;
using test1.Services;

namespace test1.Controllers
{
    public class HomeController : Controller
    {

        private static IDataGetter data = new DataGetter();

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

        /*
        public ActionResult Name(int id, string typeSet)
        {
            

            Contact contact = new Contact() {
                FirstName = "Aras",
                LastName = "Braziunas",
                Age = 23,
            };
           

        IDictionary<int, Contact> list = data.GetContacts();

            if (typeSet.Equals("up"))
            {
                return Content(list.Where(item => item.Id == id).First().FirstName.ToString().ToUpper());
            }
            else
            {
                return Content(list.Where(item => item.Id == id).First().FirstName.ToString().ToLower());
            }
        } */



        public ActionResult List()
        {
            
            return View(data.GetContacts());
        }

        public ActionResult Details(int id)
        {

            if ( id <0 || id>=data.GetContacts().Count )
            {
                throw new Exception("Error with index");
            }

            return View(data.GetContact(id));
        }

        [HttpPost]
        public ActionResult Add(Contact contact)
        {
            if (ModelState.IsValid)
            {
                data.AddContact(contact);
                return RedirectToAction("List");
            }
            else
            {
                throw new Exception("Validation error");
            }

            
            //return Content(contact.FirstName);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

    }
}