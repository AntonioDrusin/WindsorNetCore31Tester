#if AUTOFAC
using Autofac.Extensions.DependencyInjection;
#endif
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace WebApplication3
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) {
            
            return Host.CreateDefaultBuilder(args)
#if WINDSOR
                .UseWindsorContainerServiceProvider()
#endif
#if AUTOFAC
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
#endif
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                        .UseKestrel()
                        .UseStartup<Startup>();
                });
        }
    }
}
