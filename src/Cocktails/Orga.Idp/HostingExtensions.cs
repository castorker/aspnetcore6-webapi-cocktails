using Duende.IdentityServer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Orga.Idp.DbContexts;
using Orga.Idp.Services;
using Serilog;

namespace Orga.Idp;

internal static class HostingExtensions
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        // configures IIS out-of-proc settings 
        builder.Services.Configure<IISOptions>(iis =>
        {
            iis.AuthenticationDisplayName = "Windows";
            iis.AutomaticAuthentication = false;
        });
        // ..or configures IIS in-proc settings
        builder.Services.Configure<IISServerOptions>(iis =>
        {
            iis.AuthenticationDisplayName = "Windows";
            iis.AutomaticAuthentication = false;
        });

        // uncomment if you want to add a UI
        builder.Services.AddRazorPages();

        builder.Services.AddScoped<IPasswordHasher<Entities.User>,
            PasswordHasher<Entities.User>>();

        builder.Services.AddScoped<ILocalUserService, LocalUserService>();

        builder.Services.AddDbContext<IdentityDbContext>(options =>
        {
            options.UseSqlite(
                builder.Configuration
                .GetConnectionString("OrgaIdentityDBConnectionString"));
        });

        builder.Services.AddIdentityServer(options =>
            {
                // https://docs.duendesoftware.com/identityserver/v6/fundamentals/resources/api_scopes#authorization-based-on-scopes
                options.EmitStaticAudienceClaim = true;
            })
            .AddProfileService<LocalUserProfileService>()
            .AddInMemoryIdentityResources(Config.IdentityResources)
            .AddInMemoryApiScopes(Config.ApiScopes)
            .AddInMemoryApiResources(Config.ApiResources)
            .AddInMemoryClients(Config.Clients);
        //.AddTestUsers(TestUsers.Users);

        builder.Services
            .AddAuthentication()
            .AddOpenIdConnect("AAD", "Azure Active Directory", options =>
            {
                options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;
                // "issuer": "https://login.microsoftonline.com/78e67c9c-13c1-4269-ae2f-c6c5427d7407/v2.0"
                options.Authority = "https://login.microsoftonline.com/78e67c9c-13c1-4269-ae2f-c6c5427d7407/v2.0";
                options.ClientId = "d0fc7c05-e9e6-4310-98f6-c057ea7f9fb3";
                options.ClientSecret = "lDv8Q~Ckhn9DHWqyTpsSwGMjstscvuMRtudHKc9z";
                options.ResponseType = "code";
                options.CallbackPath = new PathString("/signin-aad/");
                options.SignedOutCallbackPath = new PathString("/signout-aad/");
                options.Scope.Add("email");
                options.Scope.Add("offline_access");
                options.SaveTokens = true;
            });

        return builder.Build();
    }
    
    public static WebApplication ConfigurePipeline(this WebApplication app)
    { 
        app.UseSerilogRequestLogging();
    
        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        // uncomment if you want to add a UI
        app.UseStaticFiles();
        app.UseRouting();

        app.UseIdentityServer();

        // uncomment if you want to add a UI
        app.UseAuthorization();
        app.MapRazorPages().RequireAuthorization();

        return app;
    }
}
