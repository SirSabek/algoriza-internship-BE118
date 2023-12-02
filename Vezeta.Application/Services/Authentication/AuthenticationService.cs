
using Vezeta.Application.Common.Interfaces.Authentication;
using Vezeta.Application.Common.Interfaces.Errors;
using Vezeta.Application.Common.Interfaces.Persistance;
using Vezeta.Domain.Entities;

namespace Vezeta.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public async Task<AuthenticationResult> RegisterAsync(string firstName, string lastName, string email, string password)
    {
        // check if user already exists
        var user = await _userRepository.GetUserByEmailAsync(email);

        if(user != null)
        {
            throw new DuplicateEmailException();
        }

        //Create user (unique id)
        user = new User
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password
        };

        //Save user to database
        await _userRepository.CreateUserAsync(user);

        //Generate jwt token
        var generatedToken = _jwtTokenGenerator.GenerateToken(user);

        return await Task.FromResult(new AuthenticationResult(
            user,
            generatedToken));
    }

    public async Task<AuthenticationResult> LoginAsync(string email, string password)
    {
        // check if user exists
        var user = await _userRepository.GetUserByEmailAsync(email);

        if(user == null)
        {
            throw new Exception("User does not exist");
        }

        // check if password is correct
        if(user.Password != password)
        {
            throw new Exception("Password is incorrect");
        }

        //Generate jwt token
        var generatedToken = _jwtTokenGenerator.GenerateToken(user);


        return await Task.FromResult(new AuthenticationResult(
            user,
            generatedToken));
    }

}
