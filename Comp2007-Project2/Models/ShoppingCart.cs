//Authors : Emma Hilborn(200282755),
//          Alex Friesen(200302342),
//          Dan Masci(200299037),
//          Karen Springford(200299681)

//Class : Enterprise Computing
//Semester : 4
//Professor : Tom Tsiliopolous
//Purpose : Final Team Project - E-Commerce Store
//Website Name : EzGames3.azurewebsites.net
//This is the model for our shopping cart-related pages/views & functions

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Comp2007_Project2.Models;
using System.Web.Mvc;

namespace Comp2007_Project2.Models
{
    public class ShoppingCart
    {
        StoreEntities storeDB = new StoreEntities();
        string ShoppingCartId { get; set; }
        public const string CartSessionKey = "CartId";

        public static ShoppingCart GetCart(HttpContextBase context)
        {
            var cart = new ShoppingCart();
            cart.ShoppingCartId = cart.GetCartId(context);
            return cart;
        }

        // Helper method to simplify shopping cart calls
        public static ShoppingCart GetCart(Controller controller)
        {
            return GetCart(controller.HttpContext);
        }

        /// <summary>
        /// Increase a Game's quantity in the Shopping Cart by 1.
        /// </summary>
        /// <param name="game"></param>
        /// <returns></returns>
        public int AddToCart(Game game)
        {
            // Get the matching cart and game instances
            var cartItem = storeDB.Carts.SingleOrDefault(
                c => c.OrderItemId == ShoppingCartId   
                && c.GameId == game.GameId);
            
            if (cartItem == null)
            {
                // Create a new cart item if no cart item exists
                cartItem = new OrderItem
                {
                    GameId = game.GameId,
                    OrderItemId = ShoppingCartId,  
                    Count = 1,
                    DateCreated = DateTime.Now
                };
                storeDB.Carts.Add(cartItem);
            }
            else
            {
                // If the item does exist in the cart, 
                // then add one to the quantity                
                cartItem.Count++;
            }
            // Save changes
            storeDB.SaveChanges();
            return cartItem.Count;
        }

        /// <summary>
        /// Decrease a Game's quantity in the Shopping Cart by 1.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int RemoveFromCart(int id)
        {
            // Get the cart Item by id
            var cartItem = storeDB.Carts.Single(
                cart => cart.OrderItemId == ShoppingCartId
                && cart.RecordId == id);

            int itemCount = 0;
            if (cartItem != null)
            {
                if (cartItem.Count > 1)
                {
                    cartItem.Count--;
                    itemCount = cartItem.Count;
                }                    
                else
                {
                    storeDB.Carts.Remove(cartItem);
                }

                // Save changes
                storeDB.SaveChanges();
            }
            return itemCount;
        }

        /// <summary>
        /// Delete a Game from the Shopping Cart.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public void DeleteFromCart(int gameId)
        {
            //Grab all cart items with the specific GameId.
            var items = storeDB.Carts.Where(
                cart => cart.GameId == gameId
                );

            //Remove all items of given game.
            foreach (var item in items)
            {
                storeDB.Carts.Remove(item);
            }
            // Save changes
            storeDB.SaveChanges();
        }

        /// <summary>
        /// Empty the entire Cart.
        /// </summary>
        public void EmptyCart()
        {
            var cartItems = storeDB.Carts.Where(
                cart => cart.OrderItemId == ShoppingCartId);

            foreach (var cartItem in cartItems)
            {
                storeDB.Carts.Remove(cartItem);
            }
            // Save changes
            storeDB.SaveChanges();
        }

        /// <summary>
        /// Grab all items in the Cart.
        /// </summary>
        /// <returns></returns>
        public List<OrderItem> GetCartItems()
        {
            return storeDB.Carts.Where(
                cart => cart.OrderItemId == ShoppingCartId).ToList();
        }

        /// <summary>
        /// Get the Cart's total count of items.
        /// </summary>
        /// <returns></returns>
        public int GetCount()
        {
            // Get the count of each item in the cart and sum them up
            int? count = (from cartItems in storeDB.Carts
                          where cartItems.OrderItemId == ShoppingCartId
                          select (int?)cartItems.Count).Sum();
            // Return 0 if all entries are null
            return count ?? 0;
        }

        /// <summary>
        /// Get the Cart's total price.
        /// </summary>
        /// <returns></returns>
        public decimal GetTotal()
        {
            // Multiply game price by count of that game to get 
            // the current price for each of those games in the cart
            // sum all game price totals to get the cart total
            decimal? total = (from cartItems in storeDB.Carts
                              where cartItems.OrderItemId == ShoppingCartId
                              select (int?)cartItems.Count *
                              cartItems.Game.Price).Sum();

            return total ?? decimal.Zero;
        }

        /// <summary>
        /// Create OrderDetail, process Order and empty Cart.
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public int CreateOrder(Order order)
        {
            decimal orderTotal = 0;

            var cartItems = GetCartItems();
            // Iterate over the items in the cart, 
            // adding the order details for each
            foreach (var item in cartItems)
            {
                var orderDetail = new OrderDetail
                {
                    GameId = item.GameId,
                    OrderId = order.OrderId,
                    UnitPrice = item.Game.Price,
                    Quantity = item.Count,
                    DateCreated = DateTime.Now
                };
                // Set the order total of the shopping cart
                orderTotal += (item.Count * item.Game.Price);

                storeDB.OrderDetails.Add(orderDetail);

            }
            // Set the order's total to the orderTotal count
            order.Total = orderTotal;

            // Save the order
            storeDB.SaveChanges();
            // Empty the shopping cart
            EmptyCart();
            // Return the OrderId as the confirmation number
            return order.OrderId;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public string GetCartId(HttpContextBase context)
        {
            // We're using HttpContextBase to allow access to cookies.
            if (context.Session[CartSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
                {
                    context.Session[CartSessionKey] =
                        context.User.Identity.Name;
                }
                else
                {
                    // Generate a new random GUID using System.Guid class
                    Guid tempCartId = Guid.NewGuid();
                    // Send tempCartId back to client as a cookie
                    context.Session[CartSessionKey] = tempCartId.ToString();
                }
            }
            return context.Session[CartSessionKey].ToString();
        }
        // When a user has logged in, migrate their shopping cart to
        // be associated with their username
        public void MigrateCart(string userName)
        {
            var shoppingCart = storeDB.Carts.Where(
                c => c.OrderItemId == ShoppingCartId);

            foreach (OrderItem item in shoppingCart)
            {
                item.OrderItemId = userName;
            }
            storeDB.SaveChanges();
        }
    }
}