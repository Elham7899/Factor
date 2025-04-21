using Entities.FactorDetails;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EntityConfiguration.FactorDetails;

public class FactorDetailConfiguration : IEntityTypeConfiguration<FactorDetail>
{
    public void Configure(EntityTypeBuilder<FactorDetail> builder)
    {
        // Identity Key
        builder.HasKey(p => p.Id);

        //Navigation
        builder.HasOne(x => x.Factor).WithMany(x => x.FactorDetails).HasForeignKey(x => x.FactorId);
        builder.HasOne(x => x.Product).WithMany(x => x.FactorDetails).HasForeignKey(x => x.ProductId);
    }
}
