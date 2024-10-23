using CleanArchitecture.UseCases.User.Repositories;

namespace CleanArchitecture.UseCases.Common.Handler;

public abstract class BaseHandler(IUserRepository userRepository)
{
    protected readonly IUserRepository _userRepository = userRepository;

    public Core.User.User GetUser()
    {
        var user = _userRepository.GetUser();
        if (user == null)
            return _userRepository.CreateUser(new Core.User.User());
        return user;
    }
}
