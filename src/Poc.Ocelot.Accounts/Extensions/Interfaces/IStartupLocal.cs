using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Poc.Ocelot.Accounts.DataContexts;

namespace Poc.Ocelot.Accounts.Interfaces;

public interface IStartupLocal
{
    public IConfiguration Configuration { get; }
    void ConfigureServices(IServiceCollection services);
    void Configure(IApplicationBuilder app, IWebHostEnvironment env, AccountsContext context);
}