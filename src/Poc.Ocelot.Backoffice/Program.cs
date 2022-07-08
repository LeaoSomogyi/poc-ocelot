using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Poc.Ocelot.Backoffice.Constants;

var builder = WebApplication.CreateBuilder(args);

var authenticationKey = builder.Configuration["Tokens:Key"];
var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationKey));
builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(config =>
    {
        config.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ClockSkew = TimeSpan.Zero,

            ValidIssuer = builder.Configuration["Tokens:Issuer"],
            ValidAudience = builder.Configuration["Tokens:Audience"],
            IssuerSigningKey = signingKey
        };
    });

builder.Services.AddAuthorization(options =>
    options.AddPolicy("Backoffice",
        policy => policy.RequireClaim(AppConstants.ClaimTypes.PERMISSION, AppConstants.ClaimValues.PERMISSION_BACKOFFICE)));

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.MapGet("api/orders", () =>
{
    return new { message = "This will list all orders" };
})
.RequireAuthorization("Backoffice");

app.Run();