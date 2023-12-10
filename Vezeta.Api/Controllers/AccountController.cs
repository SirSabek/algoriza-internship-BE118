using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Vezeta.Application.Common.Interfaces.Persistance;
using Vezeta.Application.Services.Authentication.Auth;
using Vezeta.Contract.Dtos.Auth;
using Vezeta.Domain.Entities;

namespace Vezeta.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[AllowAnonymous]
public class AccountController : ControllerBase
{
   
    private readonly IMapper _mapper;
    private readonly IAuthManager<User> _authManager;
    private readonly IUnitOfWork _unitOfWork;
    private readonly UserManager<Patient> _userManager;

    public AccountController(
        UserManager<Patient> userManager, 
        IMapper mapper, 
        IAuthManager<User> authManager, 
        IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _authManager = authManager;
        _unitOfWork = unitOfWork;
        _userManager = userManager;
    }

    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register([FromBody] UserDTO userDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var patient = _mapper.Map<Patient>(userDTO);
        patient.UserName = userDTO.Email;
        var result = await _userManager.CreateAsync(patient, userDTO.Password);
       
        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.Code, error.Description);
            }

            return BadRequest(ModelState);
        }

        await _userManager.AddToRoleAsync(patient, "Patient");
        return Accepted();
    }

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login([FromBody] LoginUserDTO loginDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        if (!await _authManager.ValidateUser(loginDTO.Email, loginDTO.Password))
        {
            return Unauthorized();
        }

        var token = await _authManager.CreateToken();

        return Accepted(new { Token = token });
    }

}