using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using WebApiPaises.Models;

namespace WebApiPaises
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase("PaisDB"));
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

            if (app.Services.CreateScope().ServiceProvider.GetRequiredService<ApplicationDbContext>().Database.EnsureCreated())
            {
                var context = app.Services.CreateScope().ServiceProvider.GetRequiredService<ApplicationDbContext>();

                if (!context.Paises.Any())
                {
                    context.Paises.AddRange(
                        new Pais { Id = 1, Nombre = "Argentina" },
                        new Pais { Id = 2, Nombre = "Brasil" },
                        new Pais { Id = 3, Nombre = "Colombia" }
                    );
                    context.SaveChanges();
                }
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
