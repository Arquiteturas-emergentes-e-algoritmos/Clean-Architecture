using CleanArchitecture.UseCases.Common.Command;

namespace CleanArchitecture.UseCases.MedicationPlan.Commands;

public class AddMedicationCommand : ICommandRequest
{
    public string Name { get; set; } = string.Empty;

    public DateTime TakeAt { get; set; } = DateTime.MinValue;

    public bool Validate()
    {
        if (string.IsNullOrEmpty(Name) || (TakeAt == DateTime.MinValue)) return false;
        return true;
    }
}
