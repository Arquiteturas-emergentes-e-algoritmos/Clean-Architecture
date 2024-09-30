using CleanArchitecture.UseCases.Common.Command;

namespace CleanArchitecture.UseCases.MedicationPlan.Commands;

public class GetMedicationsCommand : ICommandRequest
{
    public bool Validate() => true;
}
