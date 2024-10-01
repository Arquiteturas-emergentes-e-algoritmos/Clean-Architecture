using CleanArchitecture.Core.Glucometer;
using CleanArchitecture.UseCases.Glucometer.Commands;
using CleanArchitecture.UseCases.Glucometer.Handlers.Delete;
using CleanArchitecture.UseCases.Glucometer.Handlers.Get;
using CleanArchitecture.UseCases.Glucometer.Handlers.Post;
using CleanArchitecture.UseCases.Glucometer.Handlers.Put;
using CleanArchitecture.UseCases.Glucometer.Repositories;
using Moq;

namespace CleanArchitecture.Tests.UseCases.Glucometer.Handlers
{
    [TestClass]
    public class GlucometerHandlerTests
    {
        [TestMethod]
        public void ShouldDeleteTest()
        {
            // Arrange
            var mockRepository = new Mock<IGlucometerRepository>();
            var deleteTestCommand = new DeleteTestCommand { Id = Guid.Empty };
            var deleteTestHandler = new DeleteTestHandler(mockRepository.Object);

            mockRepository.Setup(r => r.GetById(It.IsAny<string>())).Returns(new GlucoseTest());

            // Act
            var response = deleteTestHandler.Handle(deleteTestCommand);

            // Assert
            mockRepository.Verify(r => r.Delete(It.IsAny<GlucoseTest>()), Times.Once);
            Assert.AreEqual(200, response.Status);
        }

        [TestMethod]
        public void ShouldGetAllTests()
        {
            // Arrange
            var mockRepository = new Mock<IGlucometerRepository>();
            var getTestsCommand = new GetTestsCommand();
            var getTestsHandler = new GetTestsHandler(mockRepository.Object);

            mockRepository.Setup(r => r.GetAll()).Returns(new List<GlucoseTest>());

            // Act
            var response = getTestsHandler.Handle(getTestsCommand);

            // Assert
            mockRepository.Verify(r => r.GetAll(), Times.Once);
            Assert.AreEqual(200, response.Status);
            Assert.AreEqual("There are all tests", response.Message);
        }

        [TestMethod]
        public void ShouldAddTest()
        {
            // Arrange
            var mockRepository = new Mock<IGlucometerRepository>();
            var glucoseTest = new GlucoseTest();
            var addTestCommand = new AddTestCommand { glucoseTest = glucoseTest };
            var addTestHandler = new AddTestHandler(mockRepository.Object);

            // Act
            var response = addTestHandler.Handle(addTestCommand);

            // Assert
            mockRepository.Verify(r => r.Add(It.IsAny<GlucoseTest>()), Times.Once);
            Assert.AreEqual(200, response.Status);
        }

        [TestMethod]
        public void ShouldPatchTest()
        {
            // Arrange
            var mockRepository = new Mock<IGlucometerRepository>();
            var glucoseTest = new GlucoseTest();
            var patchTestCommand = new PatchTestCommand { glucoseTest = glucoseTest };
            var patchTestHandler = new PatchTestHandler(mockRepository.Object);

            // Act
            var response = patchTestHandler.Handle(patchTestCommand);

            // Assert
            mockRepository.Verify(r => r.Add(It.IsAny<GlucoseTest>()), Times.Once);
            Assert.AreEqual(200, response.Status);
        }
    }
}
