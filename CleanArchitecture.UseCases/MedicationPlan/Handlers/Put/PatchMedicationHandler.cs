using CleanArchitecture.UseCases.Common.Command;
using CleanArchitecture.UseCases.Common.Handler;
using CleanArchitecture.UseCases.MedicationPlan.Commands;
using CleanArchitecture.UseCases.User.Repositories;

namespace CleanArchitecture.UseCases.MedicationPlan.Handlers.Put;

public class PatchMedicationHandler(IUserRepository userRepository) : BaseHandler(userRepository), IHandler<PatchMedicationCommand>
{
    public ICommandResponse Handle(PatchMedicationCommand command)
    {
        var user = GetUser();
        user.MedicationPlan.UpdateMedication(command.Medication);
        _userRepository.PatchUser(user);
        return new CommandResponse(null, 200);
    }
}
