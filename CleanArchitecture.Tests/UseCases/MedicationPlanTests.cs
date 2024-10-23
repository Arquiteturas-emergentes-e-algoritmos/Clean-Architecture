using CleanArchitecture.Core.Medication;
using CleanArchitecture.Core.User;
using CleanArchitecture.UseCases.MedicationPlan.Commands;
using CleanArchitecture.UseCases.MedicationPlan.Handlers.Delete;
using CleanArchitecture.UseCases.MedicationPlan.Handlers.Get;
using CleanArchitecture.UseCases.MedicationPlan.Handlers.Post;
using CleanArchitecture.UseCases.MedicationPlan.Handlers.Put;
using CleanArchitecture.UseCases.User.Repositories;
using Moq;

namespace CleanArchitecture.Tests.UseCases;

[TestClass]
public class MedicationPlanTests
{
    [TestMethod]
    public void ShouldDeleteMedication()
    {
        var mockUserRepository = new Mock<IUserRepository>();
        var mockUser = new User
        {
            MedicationPlan = new MedicationPlan()
        };
        var medicationId = new Guid();

        mockUserRepository.Setup(repo => repo.GetUser())
                          .Returns(mockUser);

        var handler = new DeleteMedicationHandler(mockUserRepository.Object);
        var command = new DeleteMedicationCommand
        {
            Id = medicationId
        };

        var result = handler.Handle(command);

        Assert.AreEqual(200, result.Status);
        mockUserRepository.Verify(repo => repo.PatchUser(mockUser), Times.Once);
    }

    [TestMethod]
    public void ShouldReturnAllMedications()
    {
        var mockUserRepository = new Mock<IUserRepository>();
        var mockUser = new User();
        var mockMedications = new List<Medication>
        {
            new("Insulina", DateTime.Now),
            new("Dipirona", DateTime.Now)
        };

        mockUser.MedicationPlan = new MedicationPlan { Medications = mockMedications };

        mockUserRepository.Setup(repo => repo.GetUser())
                          .Returns(mockUser);

        var handler = new GetAllMedicationsHandler(mockUserRepository.Object);
        var command = new GetMedicationsCommand();

        var result = handler.Handle(command);

        Assert.AreEqual(200, result.Status);
        Assert.AreEqual(mockMedications, result.Data);
    }

    [TestMethod]
    public void ShouldAddNewMedication()
    {
        var mockUserRepository = new Mock<IUserRepository>();
        var mockUser = new User
        {
            MedicationPlan = new MedicationPlan()
        };
        var medicationName = "Insulina";
        var medicationTime = DateTime.Now;

        mockUserRepository.Setup(repo => repo.GetUser())
                          .Returns(mockUser);

        var handler = new AddMedicationHandler(mockUserRepository.Object);
        var command = new AddMedicationCommand
        {
            Name = medicationName,
            TakeAt = medicationTime
        };

        var result = handler.Handle(command);

        Assert.AreEqual(200, result.Status);
        mockUserRepository.Verify(repo => repo.PatchUser(mockUser), Times.Once);
    }

    [TestMethod]
    public void PatchMedicationHandler_ShouldUpdateMedication()
    {
        var mockUserRepository = new Mock<IUserRepository>();
        var mockUser = new User
        {
            MedicationPlan = new MedicationPlan()
        };
        var medication = new Medication("UpdatedMed", DateTime.Now);

        mockUserRepository.Setup(repo => repo.GetUser())
                          .Returns(mockUser);

        var handler = new PatchMedicationHandler(mockUserRepository.Object);
        var command = new PatchMedicationCommand
        {
            Medication = medication
        };

        var result = handler.Handle(command);

        Assert.AreEqual(200, result.Status);
        mockUserRepository.Verify(repo => repo.PatchUser(mockUser), Times.Once);
    }
}
