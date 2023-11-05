using Microsoft.IdentityModel.Tokens;
using Backend.Settings;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Backend.Installers
{
    public class JWTInstaller : IInstallers
    {
        public void InstallServices(WebApplicationBuilder builder)
        {
            var JwtSetting = new JwtSetting();
            builder.Services.AddSingleton(JwtSetting);

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters =
                    new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = JwtSetting.Issuer,
                        ValidateAudience = true,
                        ValidAudience = JwtSetting.Audience,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtSetting.Key)),
                        ClockSkew = TimeSpan.Zero
                    };
                });
        }
    }
}
