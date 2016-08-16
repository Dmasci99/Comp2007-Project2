//Authors : Emma Hilborn(200282755),
//          Alex Friesen(200302342),
//          Dan Masci(200299037),
//          Karen Springford(200299681)

//Class : Enterprise Computing
//Semester : 4
//Professor : Tom Tsiliopolous
//Purpose : Final Team Project - E-Commerce Store
//Website Name : EzGames3.azurewebsites.net/Menu
//This is the page containing our store's sample data
//their appropriate categories (Platform).
//ALL IMAGES TAKEN FROM EBGAMES WEBSITE

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
                new Platform { Name = "3DS" }
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
                new Game { Name = "Halo Wars 2", Description = "Taking place where Halo 5 left off, enjoy 13 brand new campaigns unravelling a whole new story!", Price = 79.99M, Rating = "M", ReleaseDate = Convert.ToDateTime("2017-02-21"), ImageFullUrl ="/Assets/images/store/HaloWarsFull.jpg", ImageIconUrl ="/Assets/images/store/HaloWarsIcon.jpg", Platform = platforms.Single(p => p.Name == "XBox One"), Label = labels.Single(l => l.Name == "Pre-Order") },
                new Game { Name = "Tom Clancy's The Division", Description = "In this RPG that uses a modern military setting for the first time, fight as an agent of The Division to take back New York from a mass pandemic outbreak!", Price = 79.99M, Rating = "M", ReleaseDate = Convert.ToDateTime("2016-03-08"), ImageFullUrl ="/Assets/images/store/TheDivisionFull.jpg", ImageIconUrl ="/Assets/images/store/TheDivisionIcon.jpg", Platform = platforms.Single(p => p.Name == "XBox One"), Label = labels.Single(l => l.Name == "New Release") },
                new Game { Name = "ReCore", Description = "As one of few humans alive, you must join forces with robot companions to take the planet back from robot foes.", Price = 49.99M, Rating = "T", ReleaseDate = Convert.ToDateTime("2016-09-13"), ImageFullUrl ="/Assets/images/store/RecoreFull.jpg", ImageIconUrl ="/Assets/images/store/RecoreIcon.jpg", Platform = platforms.Single(p => p.Name == "XBox One"), Label = labels.Single(l => l.Name == "Pre-Order") },
                new Game { Name = "Mirror's Edge Catalyst", Description = "In the elegant city of Glass, follow Faith as she fights for freedom, exposing the dark secrets hidden in the city's walls.", Price = 49.99M, Rating = "T", ReleaseDate = Convert.ToDateTime("2016-06-07"), ImageFullUrl ="/Assets/images/store/MirrorsEdgeFull.jpg", ImageIconUrl ="/Assets/images/store/MirrorsEdgeIcon.jpg", Platform = platforms.Single(p => p.Name == "XBox One"), Label = labels.Single(l => l.Name == "New Release") },
                new Game { Name = "Overwatch (Origins Edition)", Description = "Choose a hero (from a wide range of options), join a team, and get ready to battle it out on the field!", Price = 79.99M, Rating = "T", ReleaseDate = Convert.ToDateTime("2016-05-24"), ImageFullUrl ="/Assets/images/store/OverwatchFull.jpg", ImageIconUrl ="/Assets/images/store/OverwatchIcon.jpg", Platform = platforms.Single(p => p.Name == "XBox One"), Label = labels.Single(l => l.Name == "Popular") },
                new Game { Name = "Monopoly", Description = "Enjoy the classic game of Monopoly, but set in a beautiful 3D world! Plus, play online with up to 6 players!", Price = 19.99M, Rating = "E", ReleaseDate = Convert.ToDateTime("2014-11-18"), ImageFullUrl ="/Assets/images/store/MonopolyFull.jpg", ImageIconUrl ="/Assets/images/store/MonopolyIcon.jpg", Platform = platforms.Single(p => p.Name == "XBox One"), Label = labels.Single(l => l.Name == "") },
                new Game { Name = "Trackmania Turbo", Description = "Put the pedal to the metal of your matchbox car on any of over 200 tracks, with 4 backgrounds!", Price = 29.99M, Rating = "E", ReleaseDate = Convert.ToDateTime("2016-03-22"), ImageFullUrl ="/Assets/images/store/TrackmaniaFull.jpg", ImageIconUrl ="/Assets/images/store/TrackmaniaIcon.jpg", Platform = platforms.Single(p => p.Name == "XBox One"), Label = labels.Single(l => l.Name == "") },
                new Game { Name = "Forza Motorsport 6", Description = "Race to your heart's content in over 450 Forzavista cars. The most realistic racing sim out there!", Price = 59.99M, Rating = "E", ReleaseDate = Convert.ToDateTime("2015-09-15"), ImageFullUrl ="/Assets/images/store/Forza6Full.jpg", ImageIconUrl ="/Assets/images/store/Forza6Icon.jpg", Platform = platforms.Single(p => p.Name == "XBox One"), Label = labels.Single(l => l.Name == "") },
                new Game { Name = "Battleborn", Description = "Make use of many types of heroes and weapons to protect the last star in the universe in this next-gen shooter by the creators of Borderlands!", Price = 39.99M, Rating = "T", ReleaseDate = Convert.ToDateTime("2015-12-31"), ImageFullUrl ="/Assets/images/store/BattlebornFull.jpg", ImageIconUrl ="/Assets/images/store/BattlebornIcon.jpg", Platform = platforms.Single(p => p.Name == "XBox One"), Label = labels.Single(l => l.Name == "") },
                new Game { Name = "No Man's Sky", Description = "In No Man's Sky, embark on a journey through an infinite universe of over 18 quintillion planets. Survive, explore, and travel to undiscovered lands! ", Price = 79.99M, Rating = "T", ReleaseDate = Convert.ToDateTime("2016-08-09"), ImageFullUrl ="/Assets/images/store/NoMansSkyFull.jpg", ImageIconUrl ="/Assets/images/store/NoMansSkyIcon.jpg", Platform = platforms.Single(p => p.Name == "PS4"), Label = labels.Single(l => l.Name == "New Release") },
                new Game { Name = "Attack on Titan", Description = "Based on the popular manga and anime, follow the story of the main characters through the anime's first season's events! Pre-order for bonus costumes!", Price = 69.99M, Rating = "RP", ReleaseDate = Convert.ToDateTime("2016-08-30"), ImageFullUrl ="/Assets/images/store/AotFull.jpg", ImageIconUrl ="/Assets/images/store/AotIcon.jpg", Platform = platforms.Single(p => p.Name == "PS4"), Label = labels.Single(l => l.Name == "Pre-Order") },
                new Game { Name = "Fairy Fencer F: Advent Dark Force", Description = "Enjoy 'Fairy Fencer F' remastered in HD on PS4! 3 new character routes have been added in this version!", Price = 79.99M, Rating = "T", ReleaseDate = Convert.ToDateTime("2016-07-26"), ImageFullUrl ="/Assets/images/store/FairyFencerFull.jpg", ImageIconUrl ="/Assets/images/store/FairyFencerIcon.jpg", Platform = platforms.Single(p => p.Name == "PS4"), Label = labels.Single(l => l.Name == "New Release") },
                new Game { Name = "LEGO Star Wars: The Force Awakens", Description = "Re-experience the tale of 'The Force Awakens' as game set in an all-LEGO world! Also includes bonus tales set between Return of the Jedi and The Force Awakens.", Price = 69.99M, Rating = "RP", ReleaseDate = Convert.ToDateTime("2016-06-28"), ImageFullUrl ="/Assets/images/store/StarWarsFull.jpg", ImageIconUrl ="/Assets/images/store/StarWarsIcon.jpg", Platform = platforms.Single(p => p.Name == "PS4"), Label = labels.Single(l => l.Name == "Popular") },
                new Game { Name = "Uncharted 4: A Thief's End", Description = "Taking place years after his latest adventure, Nathan Drake is forced to return to thievery. He will undergo a long journey if he hopes to save those he loves.", Price = 79.99M, Rating = "RP", ReleaseDate = Convert.ToDateTime("2016-05-10"), ImageFullUrl ="/Assets/images/store/UnchartedFull.jpg", ImageIconUrl ="/Assets/images/store/UnchartedIcon.jpg", Platform = platforms.Single(p => p.Name == "PS4"), Label = labels.Single(l => l.Name == "") },
                new Game { Name = "Sword Art Online: Lost Song", Description = "Based on the anime Sword Art Online, delve into the world of ALfheim Online alongside the anime's protagonist, Kirito!", Price = 69.99M, Rating = "T", ReleaseDate = Convert.ToDateTime("2015-11-17"), ImageFullUrl ="/Assets/images/store/SaoFull.jpg", ImageIconUrl ="/Assets/images/store/SaoIcon.jpg", Platform = platforms.Single(p => p.Name == "PS4"), Label = labels.Single(l => l.Name == "") },
                new Game { Name = "Tales of Zestiria", Description = "Follow the story of curious protagonist Sorey, who shoulders the burden of becoming the Shepherd. Gather a team of comrades to save the land from darkness. ", Price = 39.99M, Rating = "T", ReleaseDate = Convert.ToDateTime("2015-10-20"), ImageFullUrl ="/Assets/images/store/ZestiriaFull.jpg", ImageIconUrl ="/Assets/images/store/ZestiriaIcon.jpg", Platform = platforms.Single(p => p.Name == "PS4"), Label = labels.Single(l => l.Name == "Popular") },
                new Game { Name = "ShovelKnight", Description = "Take on perilous foes with no more than a shovel! Enjoy the 8-bit land of the Shovel Knight as you follow the code of Shovelry!", Price = 29.99M, Rating = "E", ReleaseDate = Convert.ToDateTime("2015-11-03"), ImageFullUrl ="/Assets/images/store/ShovelKnightFull.jpg", ImageIconUrl ="/Assets/images/store/ShovelKnightIcon.jpg", Platform = platforms.Single(p => p.Name == "PS4"), Label = labels.Single(l => l.Name == "") },
                new Game { Name = "Final Fantasy XV", Description = "Play as Noctis, a Prince travelling to wed his fiancé. However, his simple journey turns struggle as his homeland is overtaken by a neighboring empire. Can you take it back?", Price = 79.99M, Rating = "T", ReleaseDate = Convert.ToDateTime("2016-09-30"), ImageFullUrl ="/Assets/images/store/FfxvFull.jpg", ImageIconUrl ="/Assets/images/store/FfxvIcon.jpg", Platform = platforms.Single(p => p.Name == "PS4"), Label = labels.Single(l => l.Name == "Pre-Order") },
                new Game { Name = "Pokémon Sun", Description = "Celebrate 20 years since Japan's release of Pokémon Red and Green by buying Pokémon Sun - one of the latest games in the series!", Price = 49.99M, Rating = "RP", ReleaseDate = Convert.ToDateTime("2016-11-18"), ImageFullUrl ="/Assets/images/store/PkmnSunFull.jpg", ImageIconUrl ="/Assets/images/store/PkmnSunIcon.jpg", Platform = platforms.Single(p => p.Name == "3DS"), Label = labels.Single(l => l.Name == "Pre-Order") },
                new Game { Name = "Pokémon Moon", Description = "Celebrate 20 years since Japan's release of Pokémon Red and Green by buying Pokémon Moon - one of the latest games in the series!", Price = 49.99M, Rating = "RP", ReleaseDate = Convert.ToDateTime("2016-11-18"), ImageFullUrl ="/Assets/images/store/PkmnMoonFull.jpg", ImageIconUrl ="/Assets/images/store/PkmnMoonIcon.jpg", Platform = platforms.Single(p => p.Name == "3DS"), Label = labels.Single(l => l.Name == "Pre-Order") },
                new Game { Name = "Monster Hunter Generations", Description = "Take on new monsters in new locations, all while utilizing new game mechanics in the latest game from the popular Monster Hunter series!", Price = 49.99M, Rating = "T", ReleaseDate = Convert.ToDateTime("2016-07-15"), ImageFullUrl ="/Assets/images/store/MonsterHunterFull.jpg", ImageIconUrl ="/Assets/images/store/MonsterHunterIcon.jpg", Platform = platforms.Single(p => p.Name == "3DS"), Label = labels.Single(l => l.Name == "Popular") },
                new Game { Name = "Zero Time Dilemma", Description = "When nine participates find themselves trapped in a facility, forced to play deadly games to escape, you will have to answer the question: who lives, and who dies?", Price = 49.99M, Rating = "M", ReleaseDate = Convert.ToDateTime("2016-05-28"), ImageFullUrl ="/Assets/images/store/ZeroFull.jpg", ImageIconUrl ="/Assets/images/store/ZeroIcon.jpg", Platform = platforms.Single(p => p.Name == "3DS"), Label = labels.Single(l => l.Name == "") },
                new Game { Name = "Disney Art Academy", Description = "Bring our YOUR inner artist as you use lessons from real Disney art and Pixar animations to recreate over 80 Disney and Pixar characters!", Price = 39.99M, Rating = "RP", ReleaseDate = Convert.ToDateTime("2016-05-13"), ImageFullUrl ="/Assets/images/store/DisneyArtFull.jpg", ImageIconUrl ="/Assets/images/store/DisneyArtIcon.jpg", Platform = platforms.Single(p => p.Name == "3DS"), Label = labels.Single(l => l.Name == "") },
                new Game { Name = "LEGO Star Wars: The Force Awakens", Description = "Re-experience the tale of 'The Force Awakens' as game set in an all-LEGO world! Also includes bonus tales set between Return of the Jedi and The Force Awakens.", Price = 34.99M, Rating = "RP", ReleaseDate = Convert.ToDateTime("2016-06-28"), ImageFullUrl ="/Assets/images/store/StarWars3dsFull.jpg", ImageIconUrl ="/Assets/images/store/StarWars3dsIcon.jpg", Platform = platforms.Single(p => p.Name == "3DS"), Label = labels.Single(l => l.Name == "New Release") }
            }.ForEach(a => context.Games.Add(a));

        }
    }
}