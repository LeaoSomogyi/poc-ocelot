using Microsoft.AspNetCore.Builder;
using Poc.Ocelot.Payments;
using Poc.Ocelot.Payments.Extensions;

var builder = WebApplication.CreateBuilder(args)
    .UseStartup<Startup>();