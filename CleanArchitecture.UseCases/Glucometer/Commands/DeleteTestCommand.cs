using CleanArchitecture.UseCases.Common.Command;

namespace CleanArchitecture.UseCases.Glucometer.Commands;

public class DeleteTestCommand : ICommandRequest
{
    public Guid Id { get; set; } = Guid.Empty;
    public bool Validate()
    {
        if (Id == Guid.Empty) return false;
        return true;
    }
}
