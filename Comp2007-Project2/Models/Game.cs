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
        public virtual string Description { get; set; }
        public virtual decimal Price { get; set; }
        public virtual string Rating { get; set; }
        public virtual DateTime ReleaseDate { get; set; }
        public virtual string ImageFullUrl { get; set; }
        public virtual string ImageIconUrl { get; set; }
        public virtual Platform Platform { get; set; }
        public virtual Label Label { get; set; }

    }
}