using Microsoft.AspNetCore.Builder;
using Poc.Ocelot.Gateway;
using Poc.Ocelot.Gateway.Extensions;

var builder = WebApplication.CreateBuilder(args)
    .ConfigureAppConfiguration()
    .UseStartup<Startup>();