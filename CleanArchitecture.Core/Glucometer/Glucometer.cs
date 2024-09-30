using CleanArchitecture.Core.Common.Abstract;

namespace CleanArchitecture.Core.Glucometer;
public class Glucometer : Entity
{
    public List<GlucoseTest> GlucoseTests { get; set; } = [];
    public void AddTest(GlucoseTest test)
    {
        GlucoseTests.Add(test);
        GlucoseTests.OrderBy(t => t.Time);
    }
    public void DeleteTest(GlucoseTest test) => GlucoseTests.Remove(test);

    public void UpdateTest(GlucoseTest test)
    {
        var testFound = GlucoseTests.Find(x => x.Id == test.Id);
        if (testFound == null) return;
        GlucoseTests.Remove(testFound);
        GlucoseTests.Add(test);
        GlucoseTests.OrderBy(t => t.Time);
    }
}
