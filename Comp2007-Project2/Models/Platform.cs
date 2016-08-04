using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Comp2007_Project2.Models
{
    public class Platform
    {
        public virtual int PlatformId { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual string ImageFullUrl { get; set; }
        public virtual string ImageIconUrl { get; set; }
    }
}