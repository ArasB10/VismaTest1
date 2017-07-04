using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test1.Models;
using test1.Services;

namespace test1.Controllers
{
    public class SendController : Controller
    {
       public ActionResult Index()
        {
            return View();
        }
    }
}