using CleanArchitecture.Infrastructure.Repositories;
using CleanArchitecture.UseCases.Glucometer.Handlers.Delete;
using CleanArchitecture.UseCases.Glucometer.Handlers.Get;
using CleanArchitecture.UseCases.Glucometer.Handlers.Post;
using CleanArchitecture.UseCases.Glucometer.Handlers.Put;
using CleanArchitecture.UseCases.Glucometer.Repositories;
using CleanArchitecture.UseCases.MedicationPlan.Handlers.Delete;
using CleanArchitecture.UseCases.MedicationPlan.Handlers.Get;
using CleanArchitecture.UseCases.MedicationPlan.Handlers.Post;
using CleanArchitecture.UseCases.MedicationPlan.Handlers.Put;
using CleanArchitecture.UseCases.MedicationPlan.Repositories;

namespace CleanArchitecture.Web.Extentions;

public static class BuilderExtentions
{
    public static void AddDI(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<IMedicationPlanRepository, MedicationPlanRepository>();
        builder.Services.AddTransient<IGlucometerRepository, GlucometerRepository>();

        builder.Services.AddTransient<AddTestHandler>();
        builder.Services.AddTransient<AddMedicationHandler>();
        builder.Services.AddTransient<DeleteMedicationHandler>();
        builder.Services.AddTransient<DeleteTestHandler>();
        builder.Services.AddTransient<GetAllMedicationsHandler>();
        builder.Services.AddTransient<PatchMedicationHandler>();
        builder.Services.AddTransient<PatchTestHandler>();
        builder.Services.AddTransient<GetTestsHandler>();

    }
}
