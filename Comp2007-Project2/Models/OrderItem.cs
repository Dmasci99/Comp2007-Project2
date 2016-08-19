//Authors : Emma Hilborn(200282755),
//          Alex Friesen(200302342),
//          Dan Masci(200299037),
//          Karen Springford(200299681)

//Class : Enterprise Computing
//Semester : 4
//Professor : Tom Tsiliopolous
//Purpose : Final Team Project - E-Commerce Store
//Website Name : EzGames3.azurewebsites.net
//This is the model for our items in an order

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Comp2007_Project2.Models
{
    public class OrderItem
    {
        [Key]
        public virtual int RecordId { get; set; }
        public virtual string OrderItemId { get; set; }      
        public virtual int Count { get; set; }
        public virtual System.DateTime DateCreated { get; set; }
        public virtual int GameId { get; set; }
        public virtual Game Game { get; set; }

    }
}