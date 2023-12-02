
using Vezeta.Application.Common.Interfaces.Authentication;

namespace Vezeta.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public Task<AuthenticationResult> RegisterAsync(string firstName, string lastName, string email, string password)
    {
        // check if user already exists

        //Create user (unique id)

        //Generate jwt token
        Guid userId = Guid.NewGuid();

        var generatedToken = _jwtTokenGenerator.GenerateToken(userId, firstName, lastName);

        return Task.FromResult(new AuthenticationResult(userId, firstName, lastName, email, generatedToken));
    }

    public Task<AuthenticationResult> LoginAsync(string email, string password)
    {
        return Task.FromResult(new AuthenticationResult(Guid.NewGuid(), "John", "Doe", email, "token"));
    }

}
