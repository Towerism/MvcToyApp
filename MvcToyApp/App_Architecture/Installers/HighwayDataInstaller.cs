// [[Highway.Onramp.MVC.Data]]
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.MicroKernel.SubSystems.Configuration;
using Highway.Data;
using Highway.Data.Factories;
using Highway.Data.Repositories;
using MvcToyApp.App_Architecture.Services.Data;

namespace MvcToyApp.App_Architecture.Installers
{
    public class HighwayDataInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            var connectionString = ConfigurationManager.AppSettings["EntityFramework.ConnectionString"];
            container.Register(
                Component.For<IDomainRepositoryFactory>().ImplementedBy<DomainRepositoryFactory>(),
                Component.For<IDataContext>().ImplementedBy<DataContext>()
                .DependsOn(new { connectionString = connectionString})
                .LifestyleTransient(),
                Component.For<IRepository>().ImplementedBy<Repository>()
                .LifestyleTransient());
        }
    }
}
