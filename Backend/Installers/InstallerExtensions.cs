namespace Backend.Installers
{
    public static class InstallerExtensions
    {
        public static void MyInstallerExtensions(this IServiceCollection service, WebApplicationBuilder builder)
        {
            var installers = typeof(Program).Assembly.ExportedTypes.Where(x =>
                 typeof(IInstallers).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                 .Select(Activator.CreateInstance).Cast<IInstallers>().ToList();

            //ทำการลงทะเบียน DI
            installers.ForEach(installer => installer.InstallServices(builder));
        }
    }
}
