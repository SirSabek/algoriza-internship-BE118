using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Vezeta.Application.Common.Interfaces.Persistance;
using Vezeta.Contract.Dtos.Admin;
using Vezeta.Domain.Entities;

namespace Vezeta.Api.Controllers;


[ApiController]
[Route("api/[controller]")]
public class AdminController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly UserManager<Admin> _userManager;


    public AdminController(IUnitOfWork unitOfWork, IMapper mapper, UserManager<Admin> userManager)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _userManager = userManager;
    }

    [HttpPost("AddAdmin")]
    public async Task<IActionResult> AddAdmin(AddAdminDto addAdminDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var admin = _mapper.Map<Admin>(addAdminDto);

        admin.UserName = addAdminDto.Email;

        var result = await _userManager.CreateAsync(admin, addAdminDto.Password);
        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.Code, error.Description);
            }

            return BadRequest(ModelState);
        }

        await _userManager.AddToRoleAsync(admin, "Admin");

        await _unitOfWork.Save();
        return Ok();
    }
}