using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using Autofac.Integration.Mvc;
using System.Web.Mvc;
using MyCard.Services;
using MyCard.Controllers;
using MyCard.DB;

namespace MyCard.DI
{
    public class DependencyConfig
    {

        public static void Config()
        {
            ContainerBuilder builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterType<CardService>().As<ICardService>().SingleInstance();
            builder.RegisterType<CardController>().InstancePerRequest();
            
            IContainer container = builder.Build();
            
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}