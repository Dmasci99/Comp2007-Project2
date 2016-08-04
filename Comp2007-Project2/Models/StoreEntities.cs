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

    }
}
