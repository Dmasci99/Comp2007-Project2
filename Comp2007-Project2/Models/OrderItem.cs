using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Comp2007_Project2.Models
{
    public class OrderItem
    {
        [Key]
        public virtual int RecordId { get; set; }
        public virtual string OrderItemId { get; set; }      
        public virtual int Count { get; set; }
        public virtual System.DateTime DateCreated { get; set; }
        public virtual int GameId { get; set; }
        public virtual Game Game { get; set; }

    }
}