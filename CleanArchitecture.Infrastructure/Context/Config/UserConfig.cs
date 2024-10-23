using CleanArchitecture.Core.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Context.Config;

public class UserConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);
        builder.OwnsOne(u => u.Glucometer, g =>
        {
            g.OwnsMany(t => t.GlucoseTests);
        });
        builder.OwnsOne(u => u.MedicationPlan, m =>
        {
            m.OwnsMany(h => h.Medications, md =>
            {
                md.Ignore(x => x.Observers);
            });
        });
    }
}
