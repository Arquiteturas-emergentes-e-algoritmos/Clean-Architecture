using CleanArchitecture.UseCases.Common.Command;

namespace CleanArchitecture.UseCases.MedicationPlan.Commands;

public class DeleteMedicationCommand : ICommandRequest
{
    public Guid Id { get; set; } = Guid.Empty;

    public bool Validate()
    {
        if (Id == Guid.Empty) return false;
        return true;
    }
}
