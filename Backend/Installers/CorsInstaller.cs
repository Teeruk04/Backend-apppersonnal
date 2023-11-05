namespace Backend.Installers
{
    public class CorsInstaller : IInstallers
    {
        public static string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public void InstallServices(WebApplicationBuilder builder)
        {
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  policy =>
                                  {
                                      policy.AllowAnyOrigin()
                                      .AllowAnyHeader().AllowAnyMethod();
                                  });
            });


        }
    }
}
