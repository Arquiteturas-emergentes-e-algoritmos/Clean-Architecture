using CleanArchitecture.UseCases.Common.Command;
using CleanArchitecture.UseCases.Common.Handler;
using CleanArchitecture.UseCases.MedicationPlan.Commands;
using CleanArchitecture.UseCases.MedicationPlan.Repositories;

namespace CleanArchitecture.UseCases.MedicationPlan.Handlers.Post;

public class AddMedicationHandler(IMedicationPlanRepository medicationPlanRepository) : IHandler<AddMedicationCommand>
{
    private readonly IMedicationPlanRepository _medicationPlanRepository = medicationPlanRepository;

    public ICommandResponse Handle(AddMedicationCommand command)
    {
        _medicationPlanRepository.Add(command.Medication);
        return new CommandResponse(null, 200);
    }
}
