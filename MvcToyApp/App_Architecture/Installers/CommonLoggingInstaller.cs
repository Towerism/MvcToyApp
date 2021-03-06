// [[Highway.Onramp.MVC]]
using System;
using System.Collections.Generic;
using System.Linq;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.MicroKernel.SubSystems.Configuration;
using Common.Logging;

namespace MvcToyApp.App_Architecture.Installers
{
    public class CommonLoggingInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            /* Causes server error for some unknown reason :(
            container.Register(
                Component.For<ILog>().UsingFactoryMethod((k, c) => LogManager.GetLogger(c.RequestedType))
                );
                */
        }
    }
}
