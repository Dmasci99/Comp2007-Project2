using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Comp2007_Project2.Models
{
    public class SampleData : DropCreateDatabaseIfModelChanges<StoreEntities>
    {
        protected override void Seed(StoreEntities context)
        {
            var platforms = new List<Platform>
            {
                new Platform { Name = "XBox One" },
                new Platform { Name = "PS4" },
                new Platform { Name = "PC" }
            };

            var labels = new List<Label>
            {
                new Label { Name = "" },
                new Label { Name = "Popular" },
                new Label { Name = "Pre-Order" },
                new Label { Name = "New Release" }
            };

            new List<Game>
            {
                new Game { Name = "Assassins Creed", Description = "Description", Price = 59.99M, Rating = "M", ReleaseDate = DateTime.Now, ImageFullUrl ="images/blah.jpg", ImageIconUrl ="images/thumbnails/blah.jpg", Platform = platforms.Single(p => p.Name == "XBox One"), Label = labels.Single(l => l.Name == "") }
            }.ForEach(a => context.Games.Add(a));

        }
    }
}