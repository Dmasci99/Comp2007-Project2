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
   * This is the ShoppingCart View Page. It lists all the games within
   * their cart and the current total cost.
   * 
   */



using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Comp2007_Project2.Models;

namespace Comp2007_Project2.ViewModels
{
    public class ShoppingCartViewModel
    {
        //list to keep track of all the items in the cart
        public virtual List<OrderItem> CartItems { get; set; }

        //carries the total cost of the cart
        public virtual decimal CartTotal { get; set; }
    }
}