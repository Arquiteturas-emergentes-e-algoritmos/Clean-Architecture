using CleanArchitecture.Core.Glucometer;
using CleanArchitecture.Core.Medication;
using CleanArchitecture.UseCases.Glucometer.Commands;
using CleanArchitecture.UseCases.MedicationPlan.Commands;

namespace CleanArchitecture.Tests.UseCases;

[TestClass]
public class CommandsTests
{
    [TestMethod]
    [DataRow("2024-10-22T12:00:00", 100, true)]
    [DataRow("0001-01-01T00:00:00", 100, false)]
    [DataRow("2024-10-22T12:00:00", 0, false)]
    public void ShouldValidateAddTestCommandCorrectly(string timeStr, int value, bool expected)
    {
        var command = new AddTestCommand
        {
            Time = DateTime.Parse(timeStr),
            Value = (ushort)value
        };

        Assert.AreEqual(expected, command.Validate());
    }

    [TestMethod]
    [DataRow("00000000-0000-0000-0000-000000000000", false)]
    [DataRow("D0BBA543-1B03-4F66-BD09-B9DCE735A4F9", true)]
    public void ShouldValidateDeleteTestCommandCorrectly(string idStr, bool expected)
    {
        var command = new DeleteTestCommand
        {
            Id = Guid.Parse(idStr)
        };

        Assert.AreEqual(expected, command.Validate());
    }

    [TestMethod]
    [DataRow("Insulin", "2024-10-22T12:00:00", true)]
    [DataRow("", "2024-10-22T12:00:00", false)]
    [DataRow("Insulin", "0001-01-01T00:00:00", false)]
    public void ShouldValidateAddMedicationCommandCorrectly(string name, string takeAtStr, bool expected)
    {
        var command = new AddMedicationCommand
        {
            Name = name,
            TakeAt = DateTime.Parse(takeAtStr)
        };

        Assert.AreEqual(expected, command.Validate());
    }

    [TestMethod]
    [DataRow("00000000-0000-0000-0000-000000000000", false)]
    [DataRow("D0BBA543-1B03-4F66-BD09-B9DCE735A4F9", true)]
    public void ShouldValidateDeleteMedicationCommandCorrectly(string idStr, bool expected)
    {
        var command = new DeleteMedicationCommand
        {
            Id = Guid.Parse(idStr)
        };

        Assert.AreEqual(expected, command.Validate());
    }

    [TestMethod]
    [DataRow("2024-10-22T12:00:00", 100, true)]
    [DataRow("0001-01-01T00:00:00", 100, false)]
    [DataRow("2024-10-22T12:00:00", 0, false)]
    public void ShouldValidatePatchTestCommandCorrectly(string timeStr, int value, bool expected)
    {
        var command = new PatchTestCommand
        {
            glucoseTest = new GlucoseTest
            {
                Time = DateTime.Parse(timeStr),
                Value = (ushort)value
            }
        };

        Assert.AreEqual(expected, command.Validate());
    }

    [TestMethod]
    [DataRow("Insulin", "2024-10-22T12:00:00", true)]
    [DataRow("", "2024-10-22T12:00:00", false)]
    [DataRow("Insulin", "0001-01-01T00:00:00", false)]
    public void ShouldValidatePatchMedicationCommandCorrectly(string name, string takeAtStr, bool expected)
    {
        var command = new PatchMedicationCommand
        {
            Medication = new Medication
            {
                Name = name,
                TakeAt = DateTime.Parse(takeAtStr)
            }
        };

        Assert.AreEqual(expected, command.Validate());
    }
}
