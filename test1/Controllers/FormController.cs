using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test1.Models;
using test1.Services;

namespace test1.Controllers
{
    public class FormController : Controller
    {
        

        // GET: Form
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Contact contact)
        {
            TempData["contact"] = contact;
            return RedirectToAction("Add", "Home");
        }
    }
}