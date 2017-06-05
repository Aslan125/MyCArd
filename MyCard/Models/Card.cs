using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyCard.Models
{
    public class Card
    {
        public Card()
        {
            Categories = new List<Category>();
        }
        [Key]
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual List<Category> Categories { get; set; }
    }
}