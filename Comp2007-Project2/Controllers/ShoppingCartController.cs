/**
   * Authors : Emma Hilborn (200282755),
               Alex Friesen (200302342),
               Dan Masci (200299037)
               Karen Springford (200299681)
   * Class : Enterprise Computing
   * Semester : 4
   * Professor : Tom Tsiliopolous
   * Purpose : Final Team Project - E-Commerce Store
   * Website Name : EzGames1.azurewebsites.net/Menu
   *
   * This is the ShoppingCart Controller. 
   * 
   */



using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Comp2007_Project2.Models;
using Comp2007_Project2.ViewModels;

namespace Comp2007_Project2.Controllers
{
    public class ShoppingCartController : Controller
    {
        StoreEntities storeDB = new StoreEntities();

        // GET: ShoppingCart
        public ActionResult Index()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);

            // Set up our ViewModel
            var viewModel = new ShoppingCartViewModel
            {
                CartItems = cart.GetCartItems(),
                CartTotal = cart.GetTotal()
            };
            // Return the view
            return View(viewModel);
        }

        //
        // GET: /Store/AddToCart/5
        public ActionResult AddToCart(int id)
        {
            // Retrieve the album from the database
            var addedGame = storeDB.Games
                .Single(game => game.GameId == id);

            // Add it to the shopping cart
            var cart = ShoppingCart.GetCart(this.HttpContext);

            cart.AddToCart(addedGame);

            // Go back to the main store page for more shopping
            return RedirectToAction("Index");
        }

        //
        // AJAX: /ShoppingCart/RemoveFromCart/5
        [HttpPost]
        public ActionResult RemoveFromCart(int id)
        {
            // Remove the item from the cart
            var cart = ShoppingCart.GetCart(this.HttpContext);

            // Get the name of the game to display confirmation
            string gameName = storeDB.Carts.Single(item => item.RecordId == id).Game.Name;

            // Remove from cart
            int itemCount = cart.RemoveFromCart(id);

            // Display the confirmation message
            var results = new ShoppingCartRemoveViewModel
            {
                Message = Server.HtmlEncode(gameName) +
                    " has been removed from your shopping cart.",
                CartTotal = cart.GetTotal(),
                CartCount = cart.GetCount(),
                ItemCount = itemCount,
                DeleteId = id
            };
            return Json(results);
        }

        //
        // GET: /ShoppingCart/CartSummary
        [ChildActionOnly]
        public ActionResult CartSummary()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);

            ViewData["CartCount"] = cart.GetCount();
            return PartialView("CartSummary");
        }
    }
}