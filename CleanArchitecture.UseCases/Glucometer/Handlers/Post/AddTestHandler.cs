using CleanArchitecture.Core.Glucometer;
using CleanArchitecture.UseCases.Common.Command;
using CleanArchitecture.UseCases.Common.Handler;
using CleanArchitecture.UseCases.Glucometer.Commands;
using CleanArchitecture.UseCases.User.Repositories;

namespace CleanArchitecture.UseCases.Glucometer.Handlers.Post;

public class AddTestHandler(IUserRepository userRepository) : BaseHandler(userRepository), IHandler<AddTestCommand>
{
    public ICommandResponse Handle(AddTestCommand command)
    {
        GlucoseTest test = new(command.Value, command.Time);
        var user = GetUser();
        user.Glucometer.AddTest(test);
        _userRepository.PatchUser(user);
        return new CommandResponse(null, 200);
    }
}
