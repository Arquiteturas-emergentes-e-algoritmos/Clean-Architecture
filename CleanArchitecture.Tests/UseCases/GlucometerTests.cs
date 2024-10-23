using CleanArchitecture.Core.Glucometer;
using CleanArchitecture.Core.User;
using CleanArchitecture.UseCases.Glucometer.Commands;
using CleanArchitecture.UseCases.Glucometer.Handlers.Delete;
using CleanArchitecture.UseCases.Glucometer.Handlers.Get;
using CleanArchitecture.UseCases.Glucometer.Handlers.Post;
using CleanArchitecture.UseCases.Glucometer.Handlers.Put;
using CleanArchitecture.UseCases.User.Repositories;
using Moq;

namespace CleanArchitecture.Tests.UseCases;

[TestClass]
public class GlucometerTests
{
    [TestMethod]
    public void ShouldAddGlucoseTestWhenCommandIsValid()
    {
        var mockUserRepository = new Mock<IUserRepository>();
        var mockUser = new User
        {
            Glucometer = new Glucometer()
        };

        mockUserRepository.Setup(repo => repo.GetUser())
                          .Returns(mockUser);

        var handler = new AddTestHandler(mockUserRepository.Object);

        var command = new AddTestCommand
        {
            Value = 150,
            Time = DateTime.Now
        };

        var result = handler.Handle(command);

        Assert.AreEqual(200, result.Status);
        Assert.AreEqual(1, mockUser.Glucometer.GlucoseTests.Count);
        Assert.AreEqual(command.Value, mockUser.Glucometer.GlucoseTests.First().Value);
        mockUserRepository.Verify(repo => repo.PatchUser(mockUser), Times.Once);
    }
    [TestMethod]
    public void Handle_ShouldReturnAllGlucoseTests()
    {
        var mockUserRepository = new Mock<IUserRepository>();
        var mockUser = new User();
        var mockTests = new List<GlucoseTest>
        {
            new(150, System.DateTime.Now),
            new(180, System.DateTime.Now)
        };

        mockUser.Glucometer = new Glucometer { GlucoseTests = mockTests };

        mockUserRepository.Setup(repo => repo.GetUser())
                          .Returns(mockUser);

        var handler = new GetTestsHandler(mockUserRepository.Object);
        var command = new GetTestsCommand();

        var result = handler.Handle(command);

        Assert.AreEqual(200, result.Status);
        Assert.AreEqual(mockTests, result.Data);
        Assert.AreEqual("There are all tests", result.Message);
    }

    [TestMethod]
    public void ShouldUpdateGlucoseTest()
    {
        var mockUserRepository = new Mock<IUserRepository>();
        var mockUser = new User
        {
            Glucometer = new Glucometer()
        };
        var mockTest = new GlucoseTest(150, System.DateTime.Now);

        mockUserRepository.Setup(repo => repo.GetUser())
                          .Returns(mockUser);

        var handler = new PatchTestHandler(mockUserRepository.Object);
        var command = new PatchTestCommand
        {
            glucoseTest = mockTest
        };

        var result = handler.Handle(command);

        Assert.AreEqual(200, result.Status);
        mockUserRepository.Verify(repo => repo.PatchUser(mockUser), Times.Once);
    }

    [TestMethod]
    public void ShouldDeleteGlucoseTest()
    {
        var mockUserRepository = new Mock<IUserRepository>();
        var mockUser = new User
        {
            Glucometer = new Glucometer()
        };
        var testId = new Guid();

        mockUserRepository.Setup(repo => repo.GetUser())
                          .Returns(mockUser);

        var handler = new DeleteTestHandler(mockUserRepository.Object);
        var command = new DeleteTestCommand
        {
            Id = testId
        };

        var result = handler.Handle(command);

        Assert.AreEqual(200, result.Status);
        mockUserRepository.Verify(repo => repo.PatchUser(mockUser), Times.Once);
    }
}
