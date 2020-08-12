#if AUTOFAC
    using Autofac;
    using WebApplication3.Controllers;
#endif
#if WINDSOR
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;
    using Castle.Windsor.Extensions.DependencyInjection.Extensions;
#endif
#if MSINJECTION
    using Microsoft.Extensions.DependencyInjection;
#endif

namespace WebApplication3.Services
{
#if WINDSOR
    public class Installer: IWindsorInstaller
    {

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<ITransientService>().ImplementedBy<TransientService>().LifestyleTransient(),
                Component.For<IPerWebRequestService>().ImplementedBy<PerWebRequestService>().LifeStyle.ScopedToNetServiceScope(),
                Component.For<ITransientDependentOnPerRequestService>().ImplementedBy<TransientDependentOnDependentOnPerRequestService>().LifestyleTransient()
            );
        }
    }
#endif
#if MSINJECTION
    public class Installer 
    {

        public static void MsInstall(IServiceCollection services)
        {
            services.AddScoped<IPerWebRequestService, PerWebRequestService>();
            services.AddTransient<ITransientDependentOnPerRequestService, TransientDependentOnDependentOnPerRequestService>();
            services.AddTransient<ITransientService, TransientService>();
        }
    }
#endif
#if AUTOFAC
    public static class Installer
    {
        public static void Install(this ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<TransientService>().As<ITransientService>().InstancePerDependency();
            containerBuilder.RegisterType<TransientDependentOnDependentOnPerRequestService>().As<ITransientDependentOnPerRequestService>().InstancePerDependency().InstancePerDependency();
            containerBuilder.RegisterType<PerWebRequestService>().As<IPerWebRequestService>().InstancePerLifetimeScope();
        }
    }
#endif
}