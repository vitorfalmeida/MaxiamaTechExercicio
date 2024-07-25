using MaximaTech.Infra.RelationalData.Entity;
using Microsoft.EntityFrameworkCore;

namespace MaximaTech.Infra.RelationalData
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, DbSet<ProductEntity> products)
            : base(options)
        {
            Products = products;
        }

        public DbSet<ProductEntity> Products { get; set; }
    }
}
