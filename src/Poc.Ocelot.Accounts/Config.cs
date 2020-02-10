using IdentityServer4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace Poc.Ocelot.Accounts
{
    public class Config
    {
        public static IEnumerable<ApiResource> GetAllApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("OcelotPOC", "Ocelot Gateway testing services")
            };
        }

        public static IEnumerable<Client> GetClients([FromServices] IConfiguration configuration)
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "ClientId",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets =
                    {
                        new Secret("ClientSecret".Sha256())
                    },
                    AllowedScopes = { "OcelotPOC" },
                    AccessTokenLifetime = 3600
                }
            };
        }
    }
}
