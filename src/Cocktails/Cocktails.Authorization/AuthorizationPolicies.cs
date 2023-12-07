using Microsoft.AspNetCore.Authorization;

namespace Cocktails.Authorization
{
    public static class AuthorizationPolicies
    {
        public static AuthorizationPolicy CanAddCocktail()
        {
            return new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .RequireClaim("country", "pt")
                .RequireRole("admin")
                .Build();
        }
    }
}
