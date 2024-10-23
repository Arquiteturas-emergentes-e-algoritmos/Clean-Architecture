using CleanArchitecture.Core.Glucometer;
using CleanArchitecture.UseCases.Common.Repositories;

namespace CleanArchitecture.UseCases.MedicationPlan.Repositories;

public interface IMedicationPlanRepository : IBaseRepository<GlucoseTest>
{
}
