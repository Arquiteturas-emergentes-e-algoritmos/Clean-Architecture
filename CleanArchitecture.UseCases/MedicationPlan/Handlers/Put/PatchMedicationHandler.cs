using CleanArchitecture.UseCases.Common.Command;
using CleanArchitecture.UseCases.Common.Handler;
using CleanArchitecture.UseCases.MedicationPlan.Commands;
using CleanArchitecture.UseCases.MedicationPlan.Repositories;

namespace CleanArchitecture.UseCases.MedicationPlan.Handlers.Put;

public class PatchMedicationHandler(IMedicationPlanRepository medicationPlanRepository) : IHandler<PatchMedicationCommand>
{
    private readonly IMedicationPlanRepository _medicationPlanRepository = medicationPlanRepository;

    public ICommandResponse Handle(PatchMedicationCommand command)
    {
        _medicationPlanRepository.Update(command.Medication);
        return new CommandResponse(null, 200);
    }
}
