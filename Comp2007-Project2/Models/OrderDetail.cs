//Authors : Emma Hilborn(200282755),
//          Alex Friesen(200302342),
//          Dan Masci(200299037),
//          Karen Springford(200299681)

//Class : Enterprise Computing
//Semester : 4
//Professor : Tom Tsiliopolous
//Purpose : Final Team Project - E-Commerce Store
//Website Name : ezgames.azurewebsites.net
//This is the model for our order details  - it handles the information regarding the order

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Comp2007_Project2.Models
{
    public class OrderDetail
    {
        //keeps track of the quantity
        public virtual int OrderDetailId { get; set; }
        public virtual int Quantity { get; set; }
        public virtual decimal UnitPrice { get; set; }
        public virtual int GameId { get; set; }
        public virtual Game Game { get; set; }
        public virtual int OrderId { get; set; }
        public virtual Order Order { get; set; }
        public virtual System.DateTime DateCreated { get; set; }
    }
}