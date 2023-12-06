using Vezeta.Domain.Entities;

namespace Vezeta.Application.Services.Authentication.Auth;

public interface IAuthManager<TUser> where TUser : User
{
    Task<bool> ValidateUser(string email, string password);
    Task<string> CreateToken();
}
