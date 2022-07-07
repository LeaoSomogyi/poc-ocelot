using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Poc.Ocelot.Products.Interfaces;

public interface IStartupLocal
{
    public IConfiguration Configuration { get; }
    void ConfigureServices(IServiceCollection services);
    void Configure(IApplicationBuilder app, IWebHostEnvironment env);
}