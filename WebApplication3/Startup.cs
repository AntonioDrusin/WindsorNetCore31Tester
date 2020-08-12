#if AUTOFAC
using Autofac;
#endif
#if WINDSOR
using Castle.Windsor;
#endif
using System;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApplication3.Services;

namespace WebApplication3
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
#if MSINJECTION
            Installer.MsInstall(services);
#endif
            
        }

#if WINDSOR
        public void ConfigureContainer (IWindsorContainer container)
        {
            container.Install(new Installer());
        }
#endif

#if AUTOFAC
        public void ConfigureContainer(ContainerBuilder containerBuilder)
        {
            containerBuilder.Install();
        }
#endif

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
