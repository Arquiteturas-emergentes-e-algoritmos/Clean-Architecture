using CleanArchitecture.Core.User;
using CleanArchitecture.UseCases.Common.Handler;
using CleanArchitecture.UseCases.User.Repositories;
using Moq;

namespace CleanArchitecture.Tests.UseCases;

[TestClass]
public class BaseHandlerTest
{
    [TestMethod]
    public void ShouldReturnExistingUser()
    {
        var mockUserRepository = new Mock<IUserRepository>();
        var existingUser = new User();

        mockUserRepository.Setup(repo => repo.GetUser())
                          .Returns(existingUser);

        var handler = new TestableBaseHandler(mockUserRepository.Object);

        var result = handler.GetUser();

        Assert.AreEqual(existingUser, result);
    }

    [TestMethod]
    public void ShouldCreateNewUserWhenUserDoesNotExist()
    {
        var mockUserRepository = new Mock<IUserRepository>();
        var newUser = new User();

        mockUserRepository.Setup(repo => repo.GetUser())
                          .Returns((User)null);
        mockUserRepository.Setup(repo => repo.CreateUser(It.IsAny<User>()))
                          .Returns(newUser);

        var handler = new TestableBaseHandler(mockUserRepository.Object);

        var result = handler.GetUser();

        Assert.AreEqual(newUser, result);
        mockUserRepository.Verify(repo => repo.CreateUser(It.IsAny<User>()), Times.Once); // Verifica que CreateUser foi chamado
    }

    public class TestableBaseHandler : BaseHandler
    {
        public TestableBaseHandler(IUserRepository userRepository) : base(userRepository) { }
    }
}
