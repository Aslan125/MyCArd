using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using MyCard.DI;
using MyCard.DB;
using MyCard.Models;

namespace MyCard
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            DependencyConfig.Config();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            using (Context DB = new Context())
            {
                try
                {
                    DB.Database.Delete();
                    DB.SaveChanges();
                }
                catch (Exception)
                {

                    
                }
             

              

                  
                Card card = new Card() { Name = "Name 1", Description= "Description 1" };

                for (int i = 0; i < 5; i++)
                {
                    Category category = new Category() { Name = "Category "+(i+1) };
                    DB.Categories.Add(category);
                    DB.SaveChanges();

                    card.Categories.Add(category);
                }
              
                   

                     DB.Cards.Add(card);               
                    
                  

                  
                    DB.SaveChanges();



            }
        }
    }
}
