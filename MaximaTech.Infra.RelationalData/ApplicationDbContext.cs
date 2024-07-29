using MaximaTech.Infra.RelationalData.Entity;
using Microsoft.EntityFrameworkCore;

namespace MaximaTech.Infra.RelationalData
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<DepartmentEntity> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DepartmentEntity>()
                .HasMany(d => d.Products)
                .WithOne(p => p.Department)
                .HasForeignKey(p => p.DepartmentId);

        }
    }
}