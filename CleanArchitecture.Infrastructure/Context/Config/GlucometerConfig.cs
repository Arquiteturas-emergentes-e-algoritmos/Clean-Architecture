using CleanArchitecture.Core.Glucometer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Context.Config;

public class GlucometerConfig : IEntityTypeConfiguration<Glucometer>
{
    public void Configure(EntityTypeBuilder<Glucometer> builder)
    {
        builder.HasKey(x => x.Id);
    }
}
