using CleanArchitecture.Core.Medication;
using CleanArchitecture.UseCases.Common.Command;

namespace CleanArchitecture.UseCases.MedicationPlan.Commands;

public class AddMedicationCommand : ICommandRequest
{
    public Medication Medication { get; set; } = new Medication();
    public bool Validate()
    {
        if (string.IsNullOrEmpty(Medication.Name) || (Medication.TakeAt == DateTime.MinValue)) return false;
        return true;
    }
}
