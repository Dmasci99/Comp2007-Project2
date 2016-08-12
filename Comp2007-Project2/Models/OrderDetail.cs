using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Comp2007_Project2.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int GameId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public virtual Game Game { get; set; }
        public virtual Order Order { get; set; }
    }
}