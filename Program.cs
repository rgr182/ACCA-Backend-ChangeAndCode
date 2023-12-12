using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NLog;
using NLog.Web;
using System;
using System.IO;
using ACCA_Backend.DataAccess.Repository.Context;
using ACCA_Backend.Infraestructure;
using ACCA_Backend.Utils.Security;

var logger = NLog.LogManager.Setup()
    .LoadConfigurationFromAppSettings()
    .GetCurrentClassLogger();

// NLog: setup the path
var logPath = Path.Combine(Directory.GetCurrentDirectory(), "Logs");
if (!Directory.Exists(logPath))
{
    Directory.CreateDirectory(logPath);
}
NLog.GlobalDiagnosticsContext.Set("LogDirectory", logPath);
logger.Debug("Init main");

try
{
    var builder = WebApplication.CreateBuilder(args);

    // NLog: Setup NLog for Dependency injection
    builder.Logging.ClearProviders();
    builder.Host.UseNLog();

    builder.Services.AddCors(o =>
        o.AddPolicy("corsapp", b =>
            b.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

    builder.Services.AddControllers();

    builder.Services.AddEndpointsApiExplorer();

    builder.Services.AddSwaggerGen();

    AuthenticationConfig authenticationConfig = new AuthenticationConfig(builder);

    builder.Services.AddSingleton<AuthUtils>(new AuthUtils(builder.Configuration));

    string connectionString = builder.Configuration.GetConnectionString("AccaConnection");

    builder.Services.AddDbContext<AccaSystemContext>(options =>
    {
        options.UseSqlServer(connectionString);
    });

    DependencyRegistry registry = new DependencyRegistry(builder);

    var app = builder.Build();

    if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
    {
        app.UseSwagger(c =>
        {
            c.RouteTemplate = "swagger/{documentName}/swagger.json";
        });

        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "ACCABackend");
        });
    }

    app.UseHttpsRedirection();

    app.UseCors("corsapp");

    app.UseRouting();

    app.UseAuthentication();
    app.UseAuthorization();

    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
    });

    app.Run();
}
catch (Exception ex)
{
    logger.Error(ex, "Stopped program because of exception");
    throw;
}
finally
{
    NLog.LogManager.Shutdown();
}
