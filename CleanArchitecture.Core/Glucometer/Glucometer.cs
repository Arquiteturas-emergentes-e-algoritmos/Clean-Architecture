using CleanArchitecture.Core.Common.Abstract;

namespace CleanArchitecture.Core.Glucometer;
public class Glucometer : Entity
{
    public List<GlucoseTest> GlucoseTests { get; set; } = [];
    public void AddTest(GlucoseTest test)
    {
        GlucoseTests.Add(test);
        _ = GlucoseTests.OrderBy(t => t.Time);
    }
    public void DeleteTest(Guid id) => GlucoseTests.RemoveAll(x => x.Id == id);

    public void UpdateTest(GlucoseTest test)
    {
        var testFound = GlucoseTests.Find(x => x.Id == test.Id);
        if (testFound == null) return;
        GlucoseTests.Remove(testFound);
        GlucoseTests.Add(test);
        _ = GlucoseTests.OrderBy(t => t.Time);
    }
}
