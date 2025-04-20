using Entities.Factors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EntityConfiguration.Factors;

public class FactorConfiguration : IEntityTypeConfiguration<Factor>
{
    public void Configure(EntityTypeBuilder<Factor> builder)
    {
        // Identity Key
        builder.HasKey(p => p.Id);

        //Navigation
        builder.HasMany(x => x.FactorDetails).WithOne(x => x.Factor).HasForeignKey(x => x.FactorId);
    }
}
