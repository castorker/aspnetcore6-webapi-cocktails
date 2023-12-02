using Microsoft.AspNetCore.Authorization;

namespace Cocktails.API.Services
{
    public class MinimumAgeRequirement : IAuthorizationRequirement
    {
        public MinimumAgeRequirement(int minimumAge) =>
        MinimumAge = minimumAge;

        public int MinimumAge { get; }
    }
}
