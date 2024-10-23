using CleanArchitecture.UseCases.Common.Command;
using CleanArchitecture.UseCases.Common.Handler;
using CleanArchitecture.UseCases.Glucometer.Commands;
using CleanArchitecture.UseCases.User.Repositories;

namespace CleanArchitecture.UseCases.Glucometer.Handlers.Put;

public class PatchTestHandler(IUserRepository userRepository) : BaseHandler(userRepository), IHandler<PatchTestCommand>
{
    public ICommandResponse Handle(PatchTestCommand command)
    {
        var user = GetUser();
        user.Glucometer.UpdateTest(command.glucoseTest);
        _userRepository.PatchUser(user);
        return new CommandResponse(null, 200);
    }
}
