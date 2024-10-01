using CleanArchitecture.Core.Medication;
using CleanArchitecture.UseCases.MedicationPlan.Commands;
using CleanArchitecture.UseCases.MedicationPlan.Handlers.Delete;
using CleanArchitecture.UseCases.MedicationPlan.Handlers.Get;
using CleanArchitecture.UseCases.MedicationPlan.Handlers.Post;
using CleanArchitecture.UseCases.MedicationPlan.Handlers.Put;
using CleanArchitecture.UseCases.MedicationPlan.Repositories;
using Moq;

namespace CleanArchitecture.Tests.UseCases.MedicationPlan.Handlers
{
    [TestClass]
    public class MedicationPlanHandlerTests
    {
        [TestMethod]
        public void ShouldDeleteMedication()
        {
            // Arrange
            var mockRepository = new Mock<IMedicationPlanRepository>();
            var deleteMedicationCommand = new DeleteMedicationCommand { Id = Guid.Empty };
            var deleteMedicationHandler = new DeleteMedicationHandler(mockRepository.Object);

            mockRepository.Setup(r => r.GetById(It.IsAny<string>())).Returns(new Medication());

            // Act
            var response = deleteMedicationHandler.Handle(deleteMedicationCommand);

            // Assert
            mockRepository.Verify(r => r.Delete(It.IsAny<Medication>()), Times.Once);
            Assert.AreEqual(200, response.Status);
        }

        [TestMethod]
        public void ShouldReturnNotFoundWhenDeletingNonExistingMedication()
        {
            // Arrange
            var mockRepository = new Mock<IMedicationPlanRepository>();
            var deleteMedicationCommand = new DeleteMedicationCommand { Id = Guid.Empty };
            var deleteMedicationHandler = new DeleteMedicationHandler(mockRepository.Object);

            mockRepository.Setup(r => r.GetById(It.IsAny<string>())).Returns((Medication?)null);

            // Act
            var response = deleteMedicationHandler.Handle(deleteMedicationCommand);

            // Assert
            Assert.AreEqual(404, response.Status);
        }

        [TestMethod]
        public void ShouldGetAllMedications()
        {
            // Arrange
            var mockRepository = new Mock<IMedicationPlanRepository>();
            var getMedicationsCommand = new GetMedicationsCommand();
            var getAllMedicationsHandler = new GetAllMedicationsHandler(mockRepository.Object);

            mockRepository.Setup(r => r.GetAll()).Returns(new List<Medication>());

            // Act
            var response = getAllMedicationsHandler.Handle(getMedicationsCommand);

            // Assert
            mockRepository.Verify(r => r.GetAll(), Times.Once);
            Assert.AreEqual(200, response.Status);
        }

        [TestMethod]
        public void ShouldAddMedication()
        {
            // Arrange
            var mockRepository = new Mock<IMedicationPlanRepository>();
            var medication = new Medication();
            var addMedicationCommand = new AddMedicationCommand { Medication = medication };
            var addMedicationHandler = new AddMedicationHandler(mockRepository.Object);

            // Act
            var response = addMedicationHandler.Handle(addMedicationCommand);

            // Assert
            mockRepository.Verify(r => r.Add(It.IsAny<Medication>()), Times.Once);
            Assert.AreEqual(200, response.Status);
        }

        [TestMethod]
        public void ShouldPatchMedication()
        {
            // Arrange
            var mockRepository = new Mock<IMedicationPlanRepository>();
            var medication = new Medication();
            var patchMedicationCommand = new PatchMedicationCommand { Medication = medication };
            var patchMedicationHandler = new PatchMedicationHandler(mockRepository.Object);

            // Act
            var response = patchMedicationHandler.Handle(patchMedicationCommand);

            // Assert
            mockRepository.Verify(r => r.Update(It.IsAny<Medication>()), Times.Once);
            Assert.AreEqual(200, response.Status);
        }
    }
}
