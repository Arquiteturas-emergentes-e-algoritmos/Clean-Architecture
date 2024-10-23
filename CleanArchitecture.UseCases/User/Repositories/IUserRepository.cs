namespace CleanArchitecture.UseCases.User.Repositories;

public interface IUserRepository
{
    Core.User.User CreateUser(Core.User.User u);
    Core.User.User? GetUser();
    void PatchUser(Core.User.User u);
}
