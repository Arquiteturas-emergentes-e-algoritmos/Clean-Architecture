using CleanArchitecture.Core.Glucometer;
using CleanArchitecture.UseCases.Common.Command;

namespace CleanArchitecture.UseCases.Glucometer.Commands;

public class PatchTestCommand : ICommandRequest
{
    public GlucoseTest glucoseTest { get; set; } = new GlucoseTest();

    public bool Validate()
    {
        if (glucoseTest.Time == DateTime.MinValue || glucoseTest.Value == 0) return false;
        return true;
    }
}
