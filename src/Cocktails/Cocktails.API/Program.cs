using Cocktails.API.Authorization;
using Cocktails.API.DbContexts;
using Cocktails.API.Services;
using Cocktails.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Serilog;
using System.IdentityModel.Tokens.Jwt;
using System.Text.Json.Serialization;

namespace Cocktails.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Configure Serilog
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File("logs/cocktails.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            var builder = WebApplication.CreateBuilder(args);

            builder.Host.UseSerilog();

            // Add services to the container.

            builder.Services.AddControllers(options =>
            {
                options.ReturnHttpNotAcceptable = true;
            })
                //.AddJsonOptions(options =>
                //{
                //    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                //    options.JsonSerializerOptions.PropertyNamingPolicy = null;
                //})
                .AddNewtonsoftJson()
                .AddXmlDataContractSerializerFormatters();

            // Learn more about configuring Swagger/OpenAPI at
            // https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // register the DbContext on the container
            // getting the connection string from appSettings
            builder.Services.AddDbContext<CocktailsDbContext>(
                DbContextOptions => DbContextOptions.UseSqlite(
                    builder.Configuration["ConnectionStrings:CocktailsDBConnectionString"]));

            builder.Services.AddScoped<ICocktailsRepository, CocktailsRepository>();

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //builder.Services.AddAuthentication("Bearer")
            //    .AddJwtBearer(options =>
            //    {
            //        options.TokenValidationParameters = new()
            //        {
            //            ValidateIssuer = true,
            //            ValidateAudience = true,
            //            ValidateIssuerSigningKey = true,
            //            ValidIssuer = builder.Configuration["Authentication:Issuer"],
            //            ValidAudience = builder.Configuration["Authentication:Audience"],
            //            IssuerSigningKey = new SymmetricSecurityKey(
            //                Encoding.ASCII.GetBytes(builder.Configuration["Authentication:SecretForKey"]))
            //        };
            //    });

            //builder.Services.AddAuthorization(options =>
            //{
            //    options.AddPolicy("MustBeAtLeast18YearsOld", policy =>
            //    {
            //        policy.RequireAuthenticatedUser();
            //        policy.Requirements.Add(new MinimumAgeRequirement(18));
            //    });
            //});

            //builder.Services.AddSingleton<IAuthorizationHandler, MinimumAgeHandler>();
            builder.Services.AddScoped<IAuthorizationHandler, MinimumAgeHandler>();

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                 .AddJwtBearer(options =>
                 {
                     options.Authority = "https://localhost:5001";
                     options.Audience = "cocktailsapi";
                     options.TokenValidationParameters = new()
                     {
                         NameClaimType = "given_name",
                         RoleClaimType = "role",
                         ValidTypes = new[] { "at+jwt" }
                     };
                 });

            builder.Services.AddAuthorization(authorizationOptions =>
            {
                authorizationOptions.AddPolicy("UserCanAddCocktail",
                    AuthorizationPolicies.CanAddCocktail());

                authorizationOptions.AddPolicy("ClientApplicationCanWrite", 
                    policyBuilder =>
                    {
                        policyBuilder.RequireClaim("scope", "cocktailsapi.write");
                    });
                
                authorizationOptions.AddPolicy("MustBeAtLeast18YearsOld",
                    policyBuilder =>
                    {
                        policyBuilder.RequireAuthenticatedUser();
                        policyBuilder.AddRequirements(new MinimumAgeRequirement(18));
                    });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.Run();
        }
    }
}
