using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using MyCard.Models;


namespace MyCard.DB
{
 

    public partial class Context : DbContext
    {
        public Context()
            : base("name=MyConnect")
        {
            this.Configuration.LazyLoadingEnabled = true;
        }

        public DbSet<Card> Cards { get; set; }
        public DbSet<Category> Categories { get; set; }



    }
}
