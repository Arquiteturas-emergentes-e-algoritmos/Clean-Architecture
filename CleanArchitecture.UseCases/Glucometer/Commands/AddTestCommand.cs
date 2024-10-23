using CleanArchitecture.UseCases.Common.Command;

namespace CleanArchitecture.UseCases.Glucometer.Commands;

public class AddTestCommand : ICommandRequest
{
    public DateTime Time { get; set; } = DateTime.Now;
    public ushort Value { get; set; } = 0;
    public bool Validate()
    {
        if (Time == DateTime.MinValue || Value == 0) return false;
        return true;
    }
}
