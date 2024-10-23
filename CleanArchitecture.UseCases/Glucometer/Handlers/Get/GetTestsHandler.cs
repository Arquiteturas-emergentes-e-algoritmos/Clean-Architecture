using CleanArchitecture.UseCases.Common.Command;
using CleanArchitecture.UseCases.Common.Handler;
using CleanArchitecture.UseCases.Glucometer.Commands;
using CleanArchitecture.UseCases.User.Repositories;

namespace CleanArchitecture.UseCases.Glucometer.Handlers.Get;

public class GetTestsHandler(IUserRepository userRepository) : BaseHandler(userRepository), IHandler<GetTestsCommand>
{
    public ICommandResponse Handle(GetTestsCommand command)
    {
        return new CommandResponse(GetUser().Glucometer.GlucoseTests, "There are all tests", 200);
    }
}
