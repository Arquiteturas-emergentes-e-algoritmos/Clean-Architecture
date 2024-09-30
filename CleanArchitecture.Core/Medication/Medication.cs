using CleanArchitecture.Core.Common.Abstract;
using CleanArchitecture.Core.Common.Interfaces;
using System.Text.Json.Serialization;

namespace CleanArchitecture.Core.Medication;
public class Medication : ValueObject
{
    public Medication() { }

    public Medication(string name, DateTime takeAt)
    {
        Name = name;
        TakeAt = takeAt;
    }

    public string Name { get; set; } = string.Empty;
    public DateTime TakeAt { get; set; } = DateTime.MaxValue;
    [JsonIgnore]
    public List<IObserver>? Observers { get; set; } = [];

    public void NotifyUsers()
    {
        if (Observers == null) return;
        Observers.ForEach(o => o.Update());
    }

    public void AddObserver(IObserver o) => Observers?.Add(o);
    public void RemoveObserver(IObserver o) => Observers?.Remove(o);

}