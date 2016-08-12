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