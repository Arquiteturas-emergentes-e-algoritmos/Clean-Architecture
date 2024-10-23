using CleanArchitecture.UseCases.Common.Command;
using CleanArchitecture.UseCases.Common.Handler;
using CleanArchitecture.UseCases.MedicationPlan.Commands;
using CleanArchitecture.UseCases.User.Repositories;

namespace CleanArchitecture.UseCases.MedicationPlan.Handlers.Delete;

public class DeleteMedicationHandler(IUserRepository userRepository) : BaseHandler(userRepository),
     IHandler<DeleteMedicationCommand>
{
    public ICommandResponse Handle(DeleteMedicationCommand command)
    {
        var user = GetUser();
        user.MedicationPlan.RemoveMedication(command.Id);
        _userRepository.PatchUser(user);
        return new CommandResponse(null, 200);
    }
}
