using CleanArchitecture.UseCases.Common.Command;
using CleanArchitecture.UseCases.Common.Handler;
using CleanArchitecture.UseCases.MedicationPlan.Commands;
using CleanArchitecture.UseCases.User.Repositories;

namespace CleanArchitecture.UseCases.MedicationPlan.Handlers.Get;

public class GetAllMedicationsHandler(IUserRepository userRepository) : BaseHandler(userRepository), IHandler<GetMedicationsCommand>
{
    public ICommandResponse Handle(GetMedicationsCommand command)
    {
        return new CommandResponse(GetUser().MedicationPlan.Medications, 200);
    }
}
