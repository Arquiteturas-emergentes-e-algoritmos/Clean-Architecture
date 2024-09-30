using CleanArchitecture.UseCases.Common.Command;
using CleanArchitecture.UseCases.Common.Handler;
using CleanArchitecture.UseCases.Glucometer.Commands;
using CleanArchitecture.UseCases.Glucometer.Repositories;

namespace CleanArchitecture.UseCases.Glucometer.Handlers.Delete;

public class DeleteTestHandler(IGlucometerRepository glucometerRepository) : IHandler<DeleteTestCommand>
{
    private readonly IGlucometerRepository _glucometerRepository = glucometerRepository;

    public ICommandResponse Handle(DeleteTestCommand command)
    {
        _glucometerRepository.Delete(_glucometerRepository.GetById(command.Id.ToString()));
        return new CommandResponse(null, 200);
    }
}
