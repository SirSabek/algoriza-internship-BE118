using Vezeta.Domain.Entities;

namespace Vezeta.Application.Common.Interfaces.Authentication
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }
}