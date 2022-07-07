using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Poc.Ocelot.Gateway.Extensions.Interfaces;

namespace Poc.Ocelot.Gateway.Extensions;

public static class StartupExtensions
{
    public static WebApplicationBuilder ConfigureAppConfiguration(this WebApplicationBuilder builder)
    {
        builder.Host.ConfigureAppConfiguration((hostingContext, config) =>
        {
            config.AddJsonFile("ocelot.json", optional: false);
        });

        return builder;
    }

    public static WebApplicationBuilder UseStartup<TStartup>(this WebApplicationBuilder builder) where TStartup : IStartupLocal
    {
        var startup = Activator.CreateInstance(typeof(TStartup), builder.Configuration) as IStartupLocal;
        if (startup == null)
            throw new ArgumentException("Classe Startup.cs inválida!");

        startup.ConfigureServices(builder.Services);

        var app = builder.Build();

        startup.Configure(app, app.Environment);

        app.Run();

        return builder;
    }
}