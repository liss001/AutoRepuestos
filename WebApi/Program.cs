using Aplication.Mapping;
using Aplication.UseCases;
using Domain.Interfaces;
using Infraestructure.Data;
using Infraestructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                });
            });

            
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly("Infraestructure")
                )
            );

          
            builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

            builder.Services.AddScoped<ICliente, ClienteRepositorie>();
            builder.Services.AddScoped<IProducto, ProductoRepositorie>();
            builder.Services.AddScoped<IVenta, VentaRepositorie>();
            builder.Services.AddScoped<IVentaItem, VentaItemRepositorie>();

            
            // ===============================
            builder.Services.AddScoped<CrearCliente>();
            builder.Services.AddScoped<CrearProducto>();
            builder.Services.AddScoped<CrearVenta>();
            builder.Services.AddScoped<CrearVentaItem>();

           
            // ===============================
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // ===============================
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors("AllowAll");

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
