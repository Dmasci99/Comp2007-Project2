namespace Comp2007_Project2.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
     
    public partial class MenuEntities : DbContext
    {
        public MenuEntities()
            : base("name=MenuConnection")
        {
        } 

        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<ItemType> ItemTypes { get; set; }
        public virtual DbSet<ItemLabel> ItemLabels { get; set; }
    }
}
