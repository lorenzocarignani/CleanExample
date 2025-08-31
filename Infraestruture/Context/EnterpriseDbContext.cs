using Microsoft.EntityFrameworkCore;

namespace Infraestruture.Context
{
    public class EnterpriseDbContext : DbContext
    {
        public DbSet<Employee> Employees {  get; set; }
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

            // Configuración adicional para las entidades
            modelBuilder.Entity<Company>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Name)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.Property(c => c.Address)
                    .HasMaxLength(200);
                entity.Property(c => c.Country)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.Property(e => e.Position)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.Property(e => e.Age)
                    .IsRequired();
            });
        }
    }
}
