
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Infraestruture.Context
{
    public class EnterpriseDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Company> Companies { get; set; }

        public EnterpriseDbContext(DbContextOptions<EnterpriseDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración de la relación One-to-Many entre Company y Employee
            modelBuilder.Entity<Company>()
                .HasMany(c => c.Employees)
                .WithOne(e => e.Company)
                .HasForeignKey(e => e.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);

            // Índices para mejorar performance
            modelBuilder.Entity<Employee>()
                .HasIndex(e => e.CompanyId);

            modelBuilder.Entity<Company>()
                .HasIndex(c => c.Name);
        }
    }
}
