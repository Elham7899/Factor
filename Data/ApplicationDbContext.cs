using Entities.FactorDetails;
using Entities.Factors;
using Entities.Products;
using Microsoft.EntityFrameworkCore;

namespace Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
	public DbSet<Factor> Factors { get; set; }   
	public DbSet<FactorDetail> FactorDetails { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}