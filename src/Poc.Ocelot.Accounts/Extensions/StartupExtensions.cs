using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Poc.Ocelot.Accounts.DataContexts;
using Poc.Ocelot.Accounts.Interfaces;

namespace Poc.Ocelot.Accounts.Extensions;

public static class StartupExtensions
{
    public static WebApplicationBuilder UseStartup<TStartup>(this WebApplicationBuilder builder) where TStartup : IStartupLocal
    {
        var startup = Activator.CreateInstance(typeof(TStartup), builder.Configuration) as IStartupLocal;
        if (startup == null)
            throw new ArgumentException("Classe Startup.cs inválida!");

        startup.ConfigureServices(builder.Services);

        var dbContext = builder.Services.BuildServiceProvider().GetService<AccountsContext>();

        var app = builder.Build();

        startup.Configure(app, app.Environment, dbContext);

        app.Run();

        return builder;
    }
}