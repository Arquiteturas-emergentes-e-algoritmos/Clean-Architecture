using CleanArchitecture.UseCases.Common.Command;

namespace CleanArchitecture.UseCases.Glucometer.Commands;

public class GetTestsCommand : ICommandRequest
{
    public bool Validate() => true;
}
