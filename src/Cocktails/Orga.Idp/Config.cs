using Duende.IdentityServer;
using Duende.IdentityServer.Models;
using System.Security.Claims;

namespace Orga.Idp;

public static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[]
        { 
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResource("roles",
                "User role(s)",
                new [] { "role" }),
            new IdentityResource("country",
                "The country where the user is living in",
                new List<string>() { "country" }),
            new IdentityResource(ClaimTypes.DateOfBirth, 
                "The user date of birth",
                new [] { ClaimTypes.DateOfBirth }),
        };

    public static IEnumerable<ApiResource> ApiResources =>
     new ApiResource[]
         {
             new ApiResource("cocktailsapi",
                 "Cocktails API",
                 new [] { "role", "country", ClaimTypes.DateOfBirth })
             {
                 Scopes = { 
                     "cocktailsapi.fullaccess",
                     "cocktailsapi.read",
                     "cocktailsapi.write"
                 },
                 ApiSecrets = { new Secret("apisecret".Sha256()) }
             }
         };

    public static IEnumerable<ApiScope> ApiScopes =>
        new ApiScope[]
            {
                new ApiScope("cocktailsapi.fullaccess"),
                new ApiScope("cocktailsapi.read"),
                new ApiScope("cocktailsapi.write")
            };

    public static IEnumerable<Client> Clients =>
        new Client[] 
            {
            new Client()
                {
                    ClientName = "Cocktails",
                    ClientId = "cocktailsclient",
                    AllowedGrantTypes = GrantTypes.Code,
                    AccessTokenType = AccessTokenType.Reference,
                    AllowOfflineAccess = true,
                    UpdateAccessTokenClaimsOnRefresh = true,
                    //AccessTokenLifetime = 120,
                    //AuthorizationCodeLifetime = ...
                    //IdentityTokenLifetime = ...
                    RedirectUris =
                    {
                        "https://localhost:7112/signin-oidc"
                    },
                    PostLogoutRedirectUris =
                    {
                        "https://localhost:7112/signout-callback-oidc"
                    },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "roles",
                        //"cocktailsapi.fullaccess",
                        "cocktailsapi.read",
                        "cocktailsapi.write",
                        "country",
                        ClaimTypes.DateOfBirth
                    },
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    //RequireConsent = true,
                }
            };
}