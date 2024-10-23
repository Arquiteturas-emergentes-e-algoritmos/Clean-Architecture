using CleanArchitecture.Core.Glucometer;
using CleanArchitecture.Infrastructure.Context;
using CleanArchitecture.UseCases.MedicationPlan.Repositories;

namespace CleanArchitecture.Infrastructure.Repositories;

public class MedicationPlanRepository : IMedicationPlanRepository
{
    private readonly DataContext _context;
    public MedicationPlanRepository(DataContext context)
    {
        _context = context;
    }
    public void Add(GlucoseTest entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(GlucoseTest entity)
    {
        throw new NotImplementedException();
    }

    public List<GlucoseTest> GetAll()
    {
        throw new NotImplementedException();
    }

    public GlucoseTest GetById(string id)
    {
        throw new NotImplementedException();
    }

    public void Update(GlucoseTest entity)
    {
        throw new NotImplementedException();
    }
}
