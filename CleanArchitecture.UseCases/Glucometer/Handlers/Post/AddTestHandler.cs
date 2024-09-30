using CleanArchitecture.UseCases.Common.Command;
using CleanArchitecture.UseCases.Common.Handler;
using CleanArchitecture.UseCases.Glucometer.Commands;
using CleanArchitecture.UseCases.Glucometer.Repositories;

namespace CleanArchitecture.UseCases.Glucometer.Handlers.Post;

public class AddTestHandler(IGlucometerRepository glucometerRepository) : IHandler<AddTestCommand>
{
    private readonly IGlucometerRepository _glucometerRepository = glucometerRepository;

    public ICommandResponse Handle(AddTestCommand command)
    {
        _glucometerRepository.Add(command.glucoseTest);
        return new CommandResponse(null, 200);
    }
}
