using Microsoft.AspNetCore.Builder;
using Poc.Ocelot.Products;
using Poc.Ocelot.Products.Extensions;

var builder = WebApplication.CreateBuilder(args)
    .UseStartup<Startup>();