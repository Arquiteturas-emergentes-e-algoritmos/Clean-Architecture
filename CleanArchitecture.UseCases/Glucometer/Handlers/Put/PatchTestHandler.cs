using CleanArchitecture.UseCases.Common.Command;
using CleanArchitecture.UseCases.Common.Handler;
using CleanArchitecture.UseCases.Glucometer.Commands;
using CleanArchitecture.UseCases.Glucometer.Repositories;

namespace CleanArchitecture.UseCases.Glucometer.Handlers.Put;

public class PatchTestHandler(IGlucometerRepository glucometerRepository) : IHandler<PatchTestCommand>
{
    private readonly IGlucometerRepository _glucometerRepository = glucometerRepository;
    public ICommandResponse Handle(PatchTestCommand command)
    {
        _glucometerRepository.Add(command.glucoseTest);
        return new CommandResponse(null, 200);
    }
}
