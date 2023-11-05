using Autofac;
using Autofac.Extensions.DependencyInjection;
using System.Reflection;

namespace Backend.Installers
{
    public class ServiceInstaller : IInstallers
    {
        public void InstallServices(WebApplicationBuilder builder)
        {
            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory(containerBuilder =>
            {
                containerBuilder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .Where(t => t.Name.EndsWith("Service") || t.Name.EndsWith("Test"))
                .AsImplementedInterfaces();
            }));
        }
    }
}
