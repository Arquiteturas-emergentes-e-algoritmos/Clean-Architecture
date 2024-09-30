using CleanArchitecture.Core.Common.Abstract;

namespace CleanArchitecture.Core.Medication;
public class MedicationPlan : Entity
{
    public List<Medication> Medications { get; set; } = [];
    public DateTime BeginAt { get; set; } = DateTime.UtcNow;
    public DateTime FinishAt { get; set; } = DateTime.MaxValue;

    public void AddMedication(Medication m)
    {
        Medications.Add(m);
        Medications.OrderBy(m => m.TakeAt.TimeOfDay - DateTime.UtcNow.TimeOfDay);
    }

    public void RemoveMedication(Medication m) => Medications.Remove(m);

    public void UpdateMedication(Medication m)
    {
        var medicationFound = Medications.Find(x => x.Id == m.Id);
        if (medicationFound == null) return;
        Medications.Remove(medicationFound);
        Medications.Add(m);
        Medications.OrderBy(t => t.TakeAt.TimeOfDay);
    }
}
