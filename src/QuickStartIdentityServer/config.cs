using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Models;
using IdentityServer4.Services.InMemory;

namespace QuickStartIdentityServer.BusinessEntities
{
    public class Config
    {
        public static IEnumerable<Scope> GetScopes()
        {
            return new List<Scope>
            {
                new Scope
                {
                    Name = "api1",
                    Description = "My API",
                    ScopeSecrets = new List<Secret>
                    {
                        new Secret("secret".Sha256())
                    },
                }
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "client",

                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    // secret for authentication
                    ClientSecrets = new List<Secret>
                    {
                        new Secret("secret".Sha256())
                    },

                    // scopes that client has access to
                    AllowedScopes = new List<string>
                    {
                        "api1"
                    },         
                    AccessTokenType = AccessTokenType.Jwt,                              
                    AccessTokenLifetime = 6,                    
                },
                  // resource owner password grant client
                new Client
                {
                    ClientId = "ro.client",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,

                    ClientSecrets = new List<Secret>
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = new List<string>
                    {
                        "api1"
                    },
                    AccessTokenLifetime = 1,
                }
            };
        }

        public static List<InMemoryUser> GetUsers()
        {
            return new List<InMemoryUser>
    {
        new InMemoryUser
        {
            Subject = "1",
            Username = "alice",
            Password = "password"
        },
        new InMemoryUser
        {
            Subject = "2",
            Username = "bob",
            Password = "password"
        }
    };
        }
    }
}
