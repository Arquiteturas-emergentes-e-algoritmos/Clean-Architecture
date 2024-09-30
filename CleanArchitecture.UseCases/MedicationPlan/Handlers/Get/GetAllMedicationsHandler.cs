using CleanArchitecture.UseCases.Common.Command;
using CleanArchitecture.UseCases.Common.Handler;
using CleanArchitecture.UseCases.MedicationPlan.Commands;
using CleanArchitecture.UseCases.MedicationPlan.Repositories;

namespace CleanArchitecture.UseCases.MedicationPlan.Handlers.Get;

public class GetAllMedicationsHandler(IMedicationPlanRepository medicationPlanRepository) : IHandler<GetMedicationsCommand>
{
    private readonly IMedicationPlanRepository _medicationPlanRepository = medicationPlanRepository;

    public ICommandResponse Handle(GetMedicationsCommand command)
    {
        var Medications = _medicationPlanRepository.GetAll();
        return new CommandResponse(Medications, 200);
    }
}
