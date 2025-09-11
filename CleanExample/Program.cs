
using Application.UseCases;
using Application.UseCases.Interfaces;
using Domain.Interfaces;
using Infraestruture.Context;
using Infraestruture.Repository;
using Microsoft.EntityFrameworkCore;

namespace CleanExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddDbContext<EnterpriseDbContext>(options =>
                     options.UseSqlite(
                     builder.Configuration.GetConnectionString("DefaultConnection"),
                     b => b.MigrationsAssembly("Infraestruture")
            ));

            builder.Services.AddControllers();

            // Repositories
            builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            // Services
            builder.Services.AddScoped<ICompanyService, CompanyService>();
            builder.Services.AddScoped<IEmployeeService, EmployeeService>();

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
