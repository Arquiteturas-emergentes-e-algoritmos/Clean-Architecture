using CleanArchitecture.Core.Common.Abstract;
using CleanArchitecture.Core.Common.Interfaces;
using CleanArchitecture.Core.Medication;

namespace CleanArchitecture.Core.User;

public class User : Entity, IObserver
{
    public MedicationPlan MedicationPlan { get; set; } = new();
    public Glucometer Glucometer { get; set; } = new();

    public void Update()
    {
        return;
    }
}
