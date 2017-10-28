using Autofac;
using Autofac.Integration.Mvc;
using AutoMapper;
using GerenciadorJogos.Bootstrapper;
using GerenciadorJogos.Business.Interfaces;
using GerenciadorJogos.WebApp.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GerenciadorJogos.WebApp.App_Start
{
    public class AutoFacConfig
    {
        public static void InicializarContainer()
        {
            var builder = BootstrapContainer.InicializarContainer();

            var controllers = typeof(HomeController).Assembly;
            builder.RegisterAssemblyTypes(controllers)
                .Where(t => t.Namespace == "GerenciadorJogos.WebApp.Controllers")
                .AsSelf()
                .PropertiesAutowired();

            builder.RegisterInstance(Mapper.Configuration.CreateMapper());

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            System.Web.HttpContext.Current.Application["DependencyResolver"] = DependencyResolver.Current;
        }
    }
}