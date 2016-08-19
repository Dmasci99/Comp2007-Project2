//Authors : Emma Hilborn(200282755),
//          Alex Friesen(200302342),
//          Dan Masci(200299037),
//          Karen Springford(200299681)

//Class : Enterprise Computing
//Semester : 4
//Professor : Tom Tsiliopolous
//Purpose : Final Team Project - E-Commerce Store
//Website Name : EzGames3.azurewebsites.net
//This is the controller for our "checkout" items (shopping cart & payment processing)

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Comp2007_Project2.Models;

namespace Comp2007_Project2.Controllers
{
    [Authorize]
    public class CheckoutController : Controller
    {
        StoreEntities storeDB = new StoreEntities();
        const string PromoCode = "FREE";
        //
        // GET: /Checkout/AddressAndPayment
        public ActionResult AddressAndPayment()
        {
            return View();
        }
        //
        // POST: /Checkout/AddressAndPayment
        [HttpPost]
        public ActionResult AddressAndPayment(FormCollection values)
        {
            Order order = new Order();
            TryUpdateModel(order);

            try
            {
                if (string.Equals(values["PromoCode"], PromoCode,
                    StringComparison.OrdinalIgnoreCase) == false)
                {
                    return View(order);
                }
                else
                {
                    order.Username = User.Identity.Name;
                    order.OrderDate = DateTime.Now;

                    //Save Order
                    storeDB.Orders.Add(order);
                    storeDB.SaveChanges();
                    //Process the order - for Part 3
                    //var cart = ShoppingCart.GetCart(this.HttpContext);
                    //cart.CreateOrder(order);

                    return RedirectToAction("Complete",
                        new { id = order.OrderId });
                }
            }
            catch (System.Data.Entity.Core.UpdateException e)
            {
                return View(order);
            }

            catch (System.Data.Entity.Infrastructure.DbUpdateException ex) //DbContext
            {
                Console.WriteLine(ex.InnerException);
                return View(order);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                //Invalid - redisplay with errors
                return View(order);
            }
        }
        //
        // GET: /Checkout/Complete
        public ActionResult Complete(int id)
        {
            // Validate customer owns this order
            bool isValid = storeDB.Orders.Any(
                o => o.OrderId == id &&
                o.Username == User.Identity.Name);

            if (isValid)
            {
                return View(id);
            }
            else
            {
                return View("Error");
            }
        }
    }
}