//Authors : Emma Hilborn(200282755),
//          Alex Friesen(200302342),
//          Dan Masci(200299037),
//          Karen Springford(200299681)

//Class : Enterprise Computing
//Semester : 4
//Professor : Tom Tsiliopolous
//Purpose : Final Team Project - E-Commerce Store
//Website Name : EzGames3.azurewebsites.net
//This is the page containing the model for our "game" items

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Comp2007_Project2.Models
{
    public class Game
    {
        public virtual int GameId { get; set; }
        public virtual int PlatformId { get; set; }
        public virtual int LabelId { get; set; }
        public virtual string Name { get; set; }
        public virtual string ShortDescription { get; set; }
        public virtual string FullDescription { get; set; }
        public virtual decimal Price { get; set; }
        public virtual string Rating { get; set; }
        public virtual DateTime ReleaseDate { get; set; }
        public virtual string ImageFullUrl { get; set; }
        public virtual string ImageIconUrl { get; set; }
        public virtual Platform Platform { get; set; }
        public virtual Label Label { get; set; }

    }
}