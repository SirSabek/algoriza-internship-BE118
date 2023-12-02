using Vezeta.Application.Common.Interfaces.Persistance;
using Vezeta.Domain.Entities;

namespace Vezeta.Infrastructure.Persistance;

public class UserRepository : IUserRepository
{
    private static readonly List<User> _users = new();
    public async Task<User> CreateUserAsync(User user)
    {
        _users.Add(user);
        return await Task.FromResult(user);
    }

    public async Task<User> DeleteUserAsync(User user)
    {
        _users.Remove(user);
        return await Task.FromResult(user);
    }

    public async Task<User> GetUserByEmailAsync(string email)
    {
        return await Task.FromResult(_users.FirstOrDefault(user => user.Email == email));
    }

    public async Task<User> GetUserByIdAsync(Guid id)
    {
        return await Task.FromResult(_users.FirstOrDefault(user => user.Id == id));
    }

    public async Task<User> UpdateUserAsync(User user)
    {
        var index = _users.FindIndex(u => u.Id == user.Id);
        _users[index] = user;
        return await Task.FromResult(user);
    }
}
    
