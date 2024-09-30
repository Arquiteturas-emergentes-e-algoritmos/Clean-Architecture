using CleanArchitecture.Infrastructure.Repositories;
using CleanArchitecture.UseCases.Glucometer.Repositories;
using CleanArchitecture.UseCases.MedicationPlan.Repositories;

namespace CleanArchitecture.Web.Extentions;

public static class BuilderExtentions
{
    public static void AddDI(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<IMedicationPlanRepository, MedicationPlanRepository>();
        builder.Services.AddTransient<IGlucometerRepository, GlucometerRepository>();
    }
}
