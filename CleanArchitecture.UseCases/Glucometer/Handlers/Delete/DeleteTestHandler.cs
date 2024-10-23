using CleanArchitecture.UseCases.Common.Command;
using CleanArchitecture.UseCases.Common.Handler;
using CleanArchitecture.UseCases.Glucometer.Commands;
using CleanArchitecture.UseCases.User.Repositories;

namespace CleanArchitecture.UseCases.Glucometer.Handlers.Delete;

public class DeleteTestHandler(IUserRepository userRepository) : BaseHandler(userRepository), IHandler<DeleteTestCommand>
{
    public ICommandResponse Handle(DeleteTestCommand command)
    {
        var user = GetUser();
        user.Glucometer.DeleteTest(command.Id);
        _userRepository.PatchUser(user);
        return new CommandResponse(null, 200);
    }
}
