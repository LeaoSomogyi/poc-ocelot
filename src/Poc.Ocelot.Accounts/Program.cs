using Microsoft.AspNetCore.Builder;
using Poc.Ocelot.Accounts;
using Poc.Ocelot.Accounts.Extensions;

var builder = WebApplication.CreateBuilder(args)
    .UseStartup<Startup>();