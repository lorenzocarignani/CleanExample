
using Application.UseCases;
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


            builder.Services.AddDbContext<EnterpriseDbContext>(options =>
                     options.UseSqlite(
                     builder.Configuration.GetConnectionString("DefaultConnection"),
                     b => b.MigrationsAssembly("Infraestruture")
            ));


            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddScoped<EnterpriseDbContext>();
            builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            builder.Services.AddScoped<CompanyService>();
            builder.Services.AddScoped<EmployeeService>();

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
