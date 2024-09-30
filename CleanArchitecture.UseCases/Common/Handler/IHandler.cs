using CleanArchitecture.UseCases.Common.Command;

namespace CleanArchitecture.UseCases.Common.Handler;

public interface IHandler<T>
{
    ICommandResponse Handle(T command);
}

public interface IHandlerAsync<T>
{
    Task<ICommandResponse> Handle(T command);
}