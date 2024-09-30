using CleanArchitecture.Core.Medication;
using CleanArchitecture.Infrastructure.Context;
using CleanArchitecture.UseCases.MedicationPlan.Repositories;

namespace CleanArchitecture.Infrastructure.Repositories;

public class MedicationPlanRepository(DataContext context) : IMedicationPlanRepository
{
    private readonly DataContext _context = context;

    public void Add(Medication entity)
    {
        _context.MedicationPlans.FirstOrDefault()!.AddMedication(entity);
        _context.SaveChanges();
    }

    public void Delete(Medication entity)
    {
        throw new NotImplementedException();
    }

    public List<Medication> GetAll()
    {
        throw new NotImplementedException();
    }

    public Medication GetById(string id)
    {
        throw new NotImplementedException();
    }

    public void Update(Medication entity)
    {
        throw new NotImplementedException();
    }
}
