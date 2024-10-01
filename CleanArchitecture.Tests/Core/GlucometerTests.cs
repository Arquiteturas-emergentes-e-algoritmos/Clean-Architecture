using CleanArchitecture.Core.Glucometer;

namespace CleanArchitecture.Tests.Core;

[TestClass]
public class GlucometerTests
{
    [TestMethod]
    public void ShouldAddANewTestOnGlucometer()
    {
        var GlucoseTest = new GlucoseTest();
        var glucometer = new Glucometer();
        glucometer.AddTest(GlucoseTest);
        Assert.AreNotEqual(glucometer.GlucoseTests.Count, 0);
    }

    [TestMethod]
    public void ShouldViewAllTestsOnGlucometer()
    {
        var glucometer = new Glucometer();
        var test1 = new GlucoseTest { Value = 100, Time = DateTime.UtcNow.AddMinutes(10) };
        var test2 = new GlucoseTest { Value = 120, Time = DateTime.UtcNow.AddMinutes(5) };
        glucometer.AddTest(test1);
        glucometer.AddTest(test2);

        var tests = glucometer.GlucoseTests;

        Assert.AreEqual(2, tests.Count);
    }

    [TestMethod]
    public void ShouldUpdateTestOnGlucometer()
    {
        var glucometer = new Glucometer();
        var glucoseTest = new GlucoseTest { Value = 100 };
        glucometer.AddTest(glucoseTest);

        glucoseTest.Value = 150;
        glucometer.UpdateTest(glucoseTest);

        Assert.AreEqual(150, glucometer.GlucoseTests.First().Value);
    }

    [TestMethod]
    public void ShouldDeleteTestOnGlucometer()
    {
        var glucometer = new Glucometer();
        var glucoseTest = new GlucoseTest { Value = 100 };
        glucometer.AddTest(glucoseTest);

        glucometer.DeleteTest(glucoseTest);

        Assert.AreEqual(0, glucometer.GlucoseTests.Count);
    }
}
