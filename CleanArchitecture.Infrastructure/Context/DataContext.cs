using CleanArchitecture.Core.Glucometer;
using CleanArchitecture.Core.Medication;
using CleanArchitecture.Infrastructure.Context.Config;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Context;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public DbSet<Glucometer> Glucometers { get; set; }
    public DbSet<MedicationPlan> MedicationPlans { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration<Glucometer>(new GlucometerConfig());
        modelBuilder.ApplyConfiguration<MedicationPlan>(new MedicationPlanConfig());

    }
}
