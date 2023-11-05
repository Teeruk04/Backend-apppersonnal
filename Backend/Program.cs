using Backend.Installers;
using Backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.MyInstallerExtensions(builder);
builder.Services.AddAuthentication();



builder.Services.AddControllers();



var app = builder.Build();


// Configure the HTTP request pipeline.
app.UseCors(CorsInstaller.MyAllowSpecificOrigins);

app.UseSwagger();
app.UseSwaggerUI();
app.UseDefaultFiles();
app.UseStaticFiles();

app.UseHttpsRedirection();


app.UseAuthentication();
app.UseAuthorization();
app.MapFallbackToController("Index", "Fallback");
app.MapControllers();


app.Run();
