using CleanArchitecture.Core.Medication;
using CleanArchitecture.UseCases.Common.Command;
using CleanArchitecture.UseCases.Common.Handler;
using CleanArchitecture.UseCases.MedicationPlan.Commands;
using CleanArchitecture.UseCases.User.Repositories;

namespace CleanArchitecture.UseCases.MedicationPlan.Handlers.Post;

public class AddMedicationHandler(IUserRepository userRepository) : BaseHandler(userRepository), IHandler<AddMedicationCommand>
{

    public ICommandResponse Handle(AddMedicationCommand command)
    {
        var medication = new Medication(command.Name, command.TakeAt);
        var user = GetUser();
        user.MedicationPlan.AddMedication(medication);
        _userRepository.PatchUser(user);
        return new CommandResponse(null, 200);
    }
}
