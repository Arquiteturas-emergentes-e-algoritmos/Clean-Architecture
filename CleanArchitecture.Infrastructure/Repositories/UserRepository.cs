using CleanArchitecture.Core.User;
using CleanArchitecture.Infrastructure.Context;
using CleanArchitecture.UseCases.User.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly DataContext _context;
    public UserRepository(DataContext context)
    {
        _context = context;
    }

    public User CreateUser(User u)
    {
        _context.Users.Add(u);
        _context.SaveChanges();
        return u;
    }

    public User? GetUser()
        => _context.Users.FirstOrDefault();


    public void PatchUser(User u)
    {
        _context.Users.Attach(u);
        _context.Entry(u).State = EntityState.Modified;
        _context.SaveChanges();
    }

}
