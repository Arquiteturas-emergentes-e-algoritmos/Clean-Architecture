using CleanArchitecture.Core.Medication;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Context.Config;

public class MedicationPlanConfig : IEntityTypeConfiguration<MedicationPlan>
{
    public void Configure(EntityTypeBuilder<MedicationPlan> builder)
    {
        builder.HasKey(x => x.Id);
    }
}
