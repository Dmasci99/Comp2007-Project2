//Authors : Emma Hilborn(200282755),
//          Alex Friesen(200302342),
//          Dan Masci(200299037),
//          Karen Springford(200299681)

//Class : Enterprise Computing
//Semester : 4
//Professor : Tom Tsiliopolous
//Purpose : Final Team Project - E-Commerce Store
//Website Name : ezgames.azurewebsites.net
//This is the controller to handle directing users to our "Home", "About", or "Contact" pages

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