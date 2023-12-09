using Cocktails.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Net.Http.Headers;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddControllersWithViews();
builder.Services.AddControllersWithViews()
    .AddJsonOptions(configure => 
        configure.JsonSerializerOptions.PropertyNamingPolicy = null);

JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

builder.Services.AddAccessTokenManagement();

// create an HttpClient used for accessing the API
builder.Services.AddHttpClient("APIClient", client =>
{
    client.BaseAddress = new Uri(builder.Configuration["CocktailsAPIRoot"]);
    client.DefaultRequestHeaders.Clear();
    client.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
}).AddUserAccessTokenHandler();

builder.Services.AddHttpClient("IDPClient", client =>
{
    //client.BaseAddress = new Uri("https://localhost:5001/");
    client.BaseAddress = new Uri("https://localhost:44300/");
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
}).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
{
    options.AccessDeniedPath = "/Authentication/AccessDenied";
})
.AddOpenIdConnect(OpenIdConnectDefaults.AuthenticationScheme, options =>
{
    options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    //options.Authority = "https://localhost:5001/";
    options.Authority = "https://localhost:44300/";
    options.ClientId = "cocktailsclient";
    options.ClientSecret = "secret";
    options.ResponseType = "code";
    //options.Scope.Add("openid");
    //options.Scope.Add("profile");
    //options.CallbackPath = new PathString("signin-oidc");
    // SignedOutCallbackPath: default = host:port/signout-callback-oidc.
    // Must match with the post logout redirect URI at IDP client config if
    // we want to automatically return to the application after logging out
    // of IdentityServer.
    // To change, set SignedOutCallbackPath
    // eg: options.SignedOutCallbackPath = new PathString("pathaftersignout");
    options.SaveTokens = true;
    options.GetClaimsFromUserInfoEndpoint = true;
    options.ClaimActions.Remove("aud");
    options.ClaimActions.DeleteClaim("sid");
    options.ClaimActions.DeleteClaim("idp");
    options.Scope.Add("roles");
    options.Scope.Add("country");
    options.Scope.Add(ClaimTypes.DateOfBirth);
    //options.Scope.Add("cocktailsapi.fullaccess");
    options.Scope.Add("cocktailsapi.read");
    options.Scope.Add("cocktailsapi.write");
    options.Scope.Add("offline_access");
    options.ClaimActions.MapJsonKey("role", "role");
    options.ClaimActions.MapUniqueJsonKey("country", "country");
    options.ClaimActions.MapUniqueJsonKey(ClaimTypes.DateOfBirth, ClaimTypes.DateOfBirth);
    options.TokenValidationParameters = new()
    {
        NameClaimType = "given_name",
        RoleClaimType = "role",
    };
});

builder.Services.AddAuthorization(authorizationOptions =>
{
    authorizationOptions.AddPolicy("UserCanAddCocktail",
        AuthorizationPolicies.CanAddCocktail());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    //app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days.
    // You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseExceptionHandler();
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Cocktails}/{action=Index}/{id?}");

app.Run();
