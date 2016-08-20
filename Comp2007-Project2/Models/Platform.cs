//Authors : Emma Hilborn(200282755),
//          Alex Friesen(200302342),
//          Dan Masci(200299037),
//          Karen Springford(200299681)

//Class : Enterprise Computing
//Semester : 4
//Professor : Tom Tsiliopolous
//Purpose : Final Team Project - E-Commerce Store
//Website Name : ezgames.azurewebsites.net
//This is the model for our platforms - it handles creating the platforms for the game to be linked to

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
    }
}