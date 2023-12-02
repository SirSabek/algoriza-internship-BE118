using Vezeta.Domain.Entities;

namespace Vezeta.Application.Common.Interfaces.Persistance;

public interface IUserRepository
{
    Task<User> GetUserByEmailAsync(string email);
    Task<User> GetUserByIdAsync(Guid id);
    Task<User> CreateUserAsync(User user);
    Task<User> UpdateUserAsync(User user);
    Task<User> DeleteUserAsync(User user);
}
