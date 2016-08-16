/**
   * Authors : Emma Hilborn (200282755),
               Alex Friesen (200302342),
               Dan Masci (200299037),
               Karen Springford (200299681)
   * Class : Enterprise Computing
   * Semester : 4
   * Professor : Tom Tsiliopolous
   * Purpose : Final Team Project - E-Commerce Store
   * Website Name : EzGames3.azurewebsites.net/Store
   *
   * This is the Shopping Cart Remove. 
   * It removes the selected games from the cart.
   *
   * ITEMS TAKEN FROM EBGAMES WEBSITE
   */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Comp2007_Project2.Models;

namespace Comp2007_Project2.ViewModels
{
    public class ShoppingCartRemoveViewModel
    {
        //message to the user regarding their removal of the object
        public virtual string Message { get; set; }

        //new cart total
        public virtual decimal CartTotal { get; set; }

        //what's the current cart count
        public virtual int CartCount { get; set; }

        //what's the current item count
        public virtual int ItemCount { get; set; }

        public virtual int DeleteId { get; set; }
    }
}