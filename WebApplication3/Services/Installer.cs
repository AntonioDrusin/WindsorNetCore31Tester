using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Castle.Windsor.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.DependencyInjection;

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
#else
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
}