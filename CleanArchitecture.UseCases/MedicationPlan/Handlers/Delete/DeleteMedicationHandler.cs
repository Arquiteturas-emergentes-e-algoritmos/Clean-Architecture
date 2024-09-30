using CleanArchitecture.UseCases.Common.Command;
using CleanArchitecture.UseCases.Common.Handler;
using CleanArchitecture.UseCases.MedicationPlan.Commands;
using CleanArchitecture.UseCases.MedicationPlan.Repositories;

namespace CleanArchitecture.UseCases.MedicationPlan.Handlers.Delete;

public class DeleteMedicationHandler(IMedicationPlanRepository medicationPlanRepository)
    : IHandler<DeleteMedicationCommand>
{
    private readonly IMedicationPlanRepository _medicationPlanRepository = medicationPlanRepository;
    public ICommandResponse Handle(DeleteMedicationCommand command)
    {
        var medication = _medicationPlanRepository.GetById(command.Id.ToString());
        if (medication == null)
            return new CommandResponse(404);
        _medicationPlanRepository.Delete(medication);
        return new CommandResponse(medication, 200);
    }
}
