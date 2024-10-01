using CleanArchitecture.Core.Common.Interfaces;
using CleanArchitecture.Core.Medication;
using Moq;

namespace CleanArchitecture.Tests.Core
{
    [TestClass]
    public class MedicationTests
    {
        [TestMethod]
        public void ShouldAddObserverToMedication()
        {
            var observer = new Mock<IObserver>();
            var medication = new Medication("Ibuprofeno", DateTime.UtcNow.AddHours(1));

            medication.AddObserver(observer.Object);

            Assert.AreEqual(1, medication.Observers?.Count);
        }

        [TestMethod]
        public void ShouldRemoveObserverFromMedication()
        {
            var observer = new Mock<IObserver>();
            var medication = new Medication("Ibuprofeno", DateTime.UtcNow.AddHours(1));
            medication.AddObserver(observer.Object);

            medication.RemoveObserver(observer.Object);

            Assert.AreEqual(0, medication.Observers?.Count);
        }

        [TestMethod]
        public void ShouldNotifyObservers()
        {
            var observer1 = new Mock<IObserver>();
            var observer2 = new Mock<IObserver>();
            var medication = new Medication("Ibuprofeno", DateTime.UtcNow.AddHours(1));
            medication.AddObserver(observer1.Object);
            medication.AddObserver(observer2.Object);

            medication.NotifyUsers();

            observer1.Verify(o => o.Update(), Times.Once);
            observer2.Verify(o => o.Update(), Times.Once);
        }
    }
}
