﻿using System.Globalization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Poc.Ocelot.Payments.Extensions.Interfaces;

namespace Poc.Ocelot.Payments
{
    public class Startup : IStartupLocal
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson(options =>
            {
                var settings = options.SerializerSettings;
                settings.NullValueHandling = NullValueHandling.Ignore;
                settings.FloatFormatHandling = FloatFormatHandling.DefaultValue;
                settings.FloatParseHandling = FloatParseHandling.Double;
                settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                settings.DateFormatString = "yyyy-MM-ddTHH:mm:ss";
                settings.Culture = new CultureInfo("en-US");
                settings.ContractResolver = new DefaultContractResolver() { NamingStrategy = new SnakeCaseNamingStrategy() };
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
