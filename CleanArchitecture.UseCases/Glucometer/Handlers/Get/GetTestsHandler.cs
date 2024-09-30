using CleanArchitecture.UseCases.Common.Command;
using CleanArchitecture.UseCases.Common.Handler;
using CleanArchitecture.UseCases.Glucometer.Commands;
using CleanArchitecture.UseCases.Glucometer.Repositories;

namespace CleanArchitecture.UseCases.Glucometer.Handlers.Get;

public class GetTestsHandler(IGlucometerRepository glucometerRepository) : IHandler<GetTestsCommand>
{
    private readonly IGlucometerRepository _glucometerRepository = glucometerRepository;

    public ICommandResponse Handle(GetTestsCommand command)
    {
        return new CommandResponse(_glucometerRepository.GetAll(), "There are all tests", 200);
    }
}
