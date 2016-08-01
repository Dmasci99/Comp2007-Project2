using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Comp2007_Project2.Models
{
    public class SampleData : DropCreateDatabaseAlways<MenuEntities>
    {
        protected override void Seed(MenuEntities context)
        {
            var itemTypes = new List<ItemType>
            {
                new ItemType { Name = "Appetizer" },
                new ItemType { Name = "Main Course" },
                new ItemType { Name = "Dessert" },
                new ItemType { Name = "Beverage" }
            };

            var itemLabels = new List<ItemLabel>
            {
                new ItemLabel { Name = "" },
                new ItemLabel { Name = "New" },
                new ItemLabel { Name = "Popular" },
                new ItemLabel { Name = "Vegetarian" },
                new ItemLabel { Name = "Gluten Free" }
            };

            new List<Item>
            {
                new Item { Name = "Nachos Supreme", Price = 14.99M, ImageUrl = "/Assets/images/menu/nachos.jpg", ShortDescription = "Traditional chips with variety of toppings available.", LongDescription = "Your choice of our house-made seasoned wonton or traditional corn chips piled high and layered with a blend of cheddar cheeses, lightly-spiced ground beef, shredded lettuce, fresh Roma tomatoes, jalapenos and green onion slivers. Served with salsa and sour cream.", ItemType = itemTypes.Single(t => t.Name == "Appetizer"), ItemLabel = itemLabels.Single(l => l.Name == "") },
                new Item { Name = "Messy Fish Sandwich", Price = 13.99M, ImageUrl = "/Assets/images/menu/messyfish.jpg", ShortDescription = "It's like a burger, but with fish!", LongDescription = "THE CODFATHER OF SANDWICHES! Wild North Pacific cod fillet brew-battered in house and fried to perfection. Topped with coleslaw, fresh tomato, shredded lettuce and zesty tartar sauce on a bakery bun.", ItemType = itemTypes.Single(t => t.Name == "Main Course"), ItemLabel = itemLabels.Single(l => l.Name == "Popular") },
                new Item { Name = "Burger 101", Price = 12.99M, ImageUrl = "/Assets/images/menu/burger.jpg", ShortDescription = "Your most basic burger - no trouble.", LongDescription = "THE BASICS...BUT STILL AWESOME. Double stacked 4 oz. sirloin patties, fresh tomato, crisp leaf lettuce, red onions and mayo spread on a tasted pretzel bun.", ItemType = itemTypes.Single(t => t.Name == "Main Course"), ItemLabel = itemLabels.Single(l => l.Name == "") },
                new Item { Name = "Fajitas", Price = 19.99M, ImageUrl = "/Assets/images/menu/fajitas.jpg", ShortDescription = "Steak or chicken with all the trimmings.", LongDescription = "Seasoned thin-sliced steak or fresh acho chicken breast served with sautéed peppers and onions, a blend of three cheeses, warm flour tortillas and all the trimmings.", ItemType = itemTypes.Single(t => t.Name == "Main Course"), ItemLabel = itemLabels.Single(l => l.Name == "Popular") },
                new Item { Name = "Maple Mustard Salmon", Price = 19.99M, ImageUrl = "/Assets/images/menu/salmon.jpg", ShortDescription = "Salmon topped with in-house sauce.", LongDescription = "Pan seared Atlantic salmon topped with house-made maple mustard sauce. Served with mashed potatoes and fresh veggies.", ItemType = itemTypes.Single(t => t.Name == "Main Course"), ItemLabel = itemLabels.Single(l => l.Name == "Gluten Free") },
                new Item { Name = "Curry Bowl", Price = 14.99M, ImageUrl = "/Assets/images/menu/curry.jpg", ShortDescription = "Array of vegetables smothered in a Thai green curry sauce.", LongDescription = "Red peppers and fresh basil in an authentic Thai green curry sauce with Shanghai noodles, steamed broccoli and bok choy. Topped with fresh green onion slivers.", ItemType = itemTypes.Single(t => t.Name == "Main Course"), ItemLabel = itemLabels.Single(l => l.Name == "Vegetarian") },
                new Item { Name = "White Chocolate Cheesecake", Price = 7.99M, ImageUrl = "/Assets/images/menu/cheesecake.jpg", ShortDescription = "White Chocolate cheesecake served with whipped cream.", LongDescription = "Dark chocolate cookie crumble crust filled with white chocolate cheesecake. Served with your choice of strawberry, peanut butter or maple whiskey caramel sauce. Served with whipped cream, chocolate shavings and fresh mint.", ItemType = itemTypes.Single(t => t.Name == "Dessert"), ItemLabel = itemLabels.Single(l => l.Name == "") },
                new Item { Name = "Fully Loaded Lime Margarita", Price = 7.99M, ImageUrl = "/Assets/images/menu/margarita.jpg", ShortDescription = "Classic Margarita kicked up a notch (1.5 oz.).", LongDescription = "The classic Margarita you love kicked up a notch. Sauza Hornitos Black Barrel Anéjo Tequila double aged in whiskey barrels, hand-shaken with Triple Sec, pure Agave syrup and our fresh lemon and lime Margarita blend (1.5 oz.).", ItemType = itemTypes.Single(t => t.Name == "Beverage"), ItemLabel = itemLabels.Single(l => l.Name == "New") },
            }.ForEach(a => context.Items.Add(a));

        }
    }
}