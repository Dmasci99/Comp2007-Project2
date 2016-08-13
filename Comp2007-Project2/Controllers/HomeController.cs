using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Comp2007_Project2.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home Page
        public ActionResult Index()
        {
            ViewBag.Title = "Home";
            return View();
        }
        // GET: About Page
        public ActionResult About()
        {
            ViewBag.Title = "About";
            return View();
        }
        // GET: Contact Page
        public ActionResult Contact()
        {
            ViewBag.Title = "Contact";
            return View();
        }
    }
}