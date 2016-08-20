//Authors : Emma Hilborn(200282755),
//          Alex Friesen(200302342),
//          Dan Masci(200299037),
//          Karen Springford(200299681)

//Class : Enterprise Computing
//Semester : 4
//Professor : Tom Tsiliopolous
//Purpose : Final Team Project - E-Commerce Store
//Website Name : ezgames.azurewebsites.net/Store
//This is the controller for our store page

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Comp2007_Project2.Models;
using System.Data.SqlClient;

namespace Comp2007_Project2.Controllers
{
    public class StoreController : Controller
    {
        private StoreEntities db = new StoreEntities();

        // GET: Store
        public ActionResult Index()
        {
            List<Game> games = null;
            do
            {
                try
                {
                    games = db.Games.ToList();
                }
                catch (DataException)
                {
                    //Azure/Connection failure
                }
                catch (SqlException )
                {
                    //Timeout
                }
            } while (games == null);
            
            return View(games);
        }

        // GET: Store/Details/id
        public ActionResult Details(int? id = 0)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }
        
        // GET: Store/Delete/id
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // POST: Store/Delete/id
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Game game = db.Games.Find(id);
            db.Games.Remove(game);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
