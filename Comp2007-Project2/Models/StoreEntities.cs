//Authors : Emma Hilborn(200282755),
//          Alex Friesen(200302342),
//          Dan Masci(200299037),
//          Karen Springford(200299681)

//Class : Enterprise Computing
//Semester : 4
//Professor : Tom Tsiliopolous
//Purpose : Final Team Project - E-Commerce Store
//Website Name : EzGames3.azurewebsites.net/Store/Index
//This is the model for our store page

namespace Comp2007_Project2.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class StoreEntities : DbContext
    {
        public StoreEntities()
            : base("name=StoreConnection")
        {
        }

        //Create our tables
        public virtual DbSet<Platform> Platforms { get; set; }
        public virtual DbSet<Label> Labels { get; set; }
        public virtual DbSet<Game> Games { get; set; }

        //Keeps track of all the carts (table)
        public virtual DbSet<OrderItem> Carts { get; set; }

        //Tracks the Orders (table)
        public virtual DbSet<Order> Orders  { get; set; }

        //Keeps the Order Details (table)
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    }
}
