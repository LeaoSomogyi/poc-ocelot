using System;
using Microsoft.AspNetCore.Builder;
using Poc.Ocelot.Payments.Extensions.Interfaces;

namespace Poc.Ocelot.Payments.Extensions;

public static class StartupExtensions
{
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