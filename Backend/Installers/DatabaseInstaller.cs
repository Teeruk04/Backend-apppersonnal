using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Installers
{
    public class DatabaseInstaller : IInstallers
    {
        public void InstallServices(WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<DatabaseContext>(opt => {
                opt.UseSqlServer(builder.Configuration.GetConnectionString("PorsonnelContext"));
                //opt.UseSqlite("Data source=personal.db");
            });
        }
    }
}
