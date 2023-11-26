using Cocktails.API.DbContexts;
using Cocktails.API.Services;
using Microsoft.EntityFrameworkCore;

namespace Cocktails.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            // register the DbContext on the container
            // getting the connection string from appSettings
            builder.Services.AddDbContext<CocktailsDbContext>(
                DbContextOptions => DbContextOptions.UseSqlite(
                    builder.Configuration["ConnectionStrings:CocktailsDBConnectionString"]));

            builder.Services.AddScoped<ICocktailsRepository, CocktailsRepository>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
