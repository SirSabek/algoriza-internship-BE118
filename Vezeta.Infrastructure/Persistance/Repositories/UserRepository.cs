using Vezeta.Application.Common.Interfaces.Persistance;
using Vezeta.Domain.Entities;
using Vezeta.Infrastructure.Persistance;

namespace Vezeta.Infrastructure.Repositories.Persistance;

public class UserRepository : IUserRepository
{
    public Task<User> CreateUserAsync(User user)
    {
        throw new NotImplementedException();
    }

    public Task<User> DeleteUserAsync(User user)
    {
        throw new NotImplementedException();
    }

    public Task<User> GetUserByEmailAsync(string email)
    {
        throw new NotImplementedException();
    }

    public Task<User> GetUserByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<User> UpdateUserAsync(User user)
    {
        throw new NotImplementedException();
    }
}

