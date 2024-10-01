using CleanArchitecture.Core.Medication;

namespace CleanArchitecture.Tests.Core
{
    [TestClass]
    public class MedicationPlanTests
    {
        [TestMethod]
        public void ShouldAddMedicationToPlan()
        {
            var medication = new Medication("Paracetamol", DateTime.UtcNow.AddHours(2));
            var medicationPlan = new MedicationPlan();

            medicationPlan.AddMedication(medication);

            Assert.AreEqual(1, medicationPlan.Medications.Count);
            Assert.AreEqual(medication, medicationPlan.Medications.First());
        }

        [TestMethod]
        public void ShouldRemoveMedicationFromPlan()
        {
            var medication = new Medication("Ibuprofeno", DateTime.UtcNow.AddHours(1));
            var medicationPlan = new MedicationPlan();
            medicationPlan.AddMedication(medication);

            medicationPlan.RemoveMedication(medication);

            Assert.AreEqual(0, medicationPlan.Medications.Count);
        }

        [TestMethod]
        public void ShouldUpdateMedicationInPlan()
        {
            var medication = new Medication("Aspirina", DateTime.UtcNow.AddHours(3));
            var updatedMedication = new Medication("Aspirina", DateTime.UtcNow.AddHours(4))
            {
                Id = medication.Id
            };
            var medicationPlan = new MedicationPlan();
            medicationPlan.AddMedication(medication);

            medicationPlan.UpdateMedication(updatedMedication);

            Assert.AreEqual(1, medicationPlan.Medications.Count);
            Assert.AreEqual(updatedMedication.TakeAt, medicationPlan.Medications.First().TakeAt);
        }
    }
}
