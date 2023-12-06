
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Vezeta.Application.Common.Interfaces.Authentication;
using Vezeta.Domain.Entities;

namespace Vezeta.Application.Services.Authentication.Auth;

public class AuthManager<TUser> : IAuthManager<TUser> where TUser : User
{
    private readonly UserManager<TUser> _userManager;
    private readonly IConfiguration _configuration;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    private TUser _user;

    public AuthManager(UserManager<TUser> userManager, IConfiguration configuration, IJwtTokenGenerator jwtTokenGenerator)
    {
        _userManager = userManager;
        _configuration = configuration;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<bool> ValidateUser(string email, string password)
    {
        _user = await _userManager.FindByNameAsync(email);

        return _user != null && await _userManager.CheckPasswordAsync(_user, password);
    }
    public async Task<string> CreateToken()
    {
        var token =  _jwtTokenGenerator.GenerateToken(_user); 

        return await Task.FromResult(token);
    }

}
