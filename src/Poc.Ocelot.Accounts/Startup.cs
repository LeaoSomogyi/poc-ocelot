using System.Globalization;
using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Poc.Ocelot.Accounts.Constants;
using Poc.Ocelot.Accounts.DataContexts;
using Poc.Ocelot.Accounts.Interfaces.Repositories;
using Poc.Ocelot.Accounts.Interfaces.Services;
using Poc.Ocelot.Accounts.Repositories;
using Poc.Ocelot.Accounts.Services;

namespace Poc.Ocelot.Accounts
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureDependencyInjection(services);
            ConfigureJWT(services);
            ConfigureDatabase(services);

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

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, AccountsContext accountsContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            accountsContext.Database.Migrate();

            app.UseAuthentication();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void ConfigureJWT(IServiceCollection services)
        {
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Tokens:Key"]));
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(config =>
            {
                config.RequireHttpsMetadata = false;
                config.SaveToken = true;
                config.TokenValidationParameters = new TokenValidationParameters()
                {
                    IssuerSigningKey = signingKey,
                    ValidateAudience = true,
                    ValidAudience = Configuration["Tokens:Audience"],
                    ValidateIssuer = false,
                    ValidIssuer = Configuration["Tokens:Issuer"],
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true
                };
            });
        }

        private void ConfigureDatabase(IServiceCollection services)
        {
            services.AddEntityFrameworkSqlServer().AddDbContext<AccountsContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DatabaseConnection"),
                    sqlOptions => sqlOptions.MigrationsAssembly(typeof(AccountsContext)
                    .GetTypeInfo().Assembly.GetName().Name));
            });
        }

        private void ConfigureDependencyInjection(IServiceCollection services)
        {
            services.Configure<AppSettings>(Configuration);
            services.AddScoped<DbContext, AccountsContext>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IAccountService, AccountService>();
        }

    }
}
