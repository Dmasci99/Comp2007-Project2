using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Comp2007_Project2.Models
{
    public class Item
    {
        public virtual int ItemId { get; set; }
        public virtual int ItemTypeId { get; set; }
        public virtual int ItemLabelId { get; set; }
        public virtual string Name { get; set; }
        public virtual decimal Price { get; set; }
        public virtual string ImageUrl { get; set; }
        public virtual string ShortDescription { get; set; }
        public virtual string LongDescription { get; set; }
        public virtual ItemType ItemType { get; set; }
        public virtual ItemLabel ItemLabel { get; set; }
    }
}