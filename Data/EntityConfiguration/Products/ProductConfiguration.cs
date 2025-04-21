using Entities.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EntityConfiguration.Products;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        //Name And Schema
        //builder.ToTable("Products", "Product");

        // Identity Key
        builder.HasKey(p => p.Id);

        //Navigation
        builder.HasMany(x => x.FactorDetails).WithOne(x => x.Product).HasForeignKey(x => x.ProductId);
    }
}
