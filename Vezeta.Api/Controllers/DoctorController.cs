using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Vezeta.Application.Common;
using Vezeta.Application.Common.Interfaces.Persistance;
using Vezeta.Contract.Dtos.Doctor;
using Vezeta.Domain.Entities;

namespace Vezeta.Api.Controllers;

[ApiController]
[Route("doctor")]

public class DoctorController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly UserManager<Doctor> _userManager;

    public DoctorController(IUnitOfWork unitOfWork, IMapper mapper, UserManager<Doctor> userManager)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _userManager = userManager;
    }


    [HttpGet("doctors")]
    public async Task<IActionResult> GetDoctors([FromQuery] RequestParams requestParams)
    {
        var doctors = await _unitOfWork.Doctors.GetPagedList(requestParams, new List<string> { "Specialization" });
        var result = _mapper.Map<List<GetDoctorDto>>(doctors);
        return Ok(result);
    }

    [HttpGet("doctor/{id:int}")]
    public async Task<IActionResult> GetDoctor(int id)
    {
        var doctor = await _unitOfWork.Doctors.Get(q => q.Id == id, new List<string> { "Specialization" });
        var result = _mapper.Map<GetDoctorDto>(doctor); 
        return Ok(result);
    }

    [HttpPost("AddDoctor")]
    public async Task<IActionResult> AddDoctor([FromBody] AddDoctorDto doctorDto)
    {
        var doctor = _mapper.Map<Doctor>(doctorDto);
        doctor.UserName = doctorDto.Email;
        await _userManager.CreateAsync(doctor, doctorDto.Password);
        await _unitOfWork.Save();
        return Ok(doctorDto);
    }
    
    [Authorize(Roles = "Doctor")]

    [HttpPut("id:int", Name ="UpdateDoctor")]
    public async Task<IActionResult> UpdateDoctor([FromBody] UpdateDoctorDto doctorDto)
    {
        //extract id from token
        var id = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
        var doctor = await _unitOfWork.Doctors.Get(q => q.Id == Convert.ToInt32(id), new List<string> { "Specialization" });
        doctor = _mapper.Map(doctorDto, doctor);
        _unitOfWork.Doctors.Update(doctor);
        await _unitOfWork.Save();
        return NoContent();
    }

    [HttpDelete("DeleteDoctor")]
    public async Task<IActionResult> DeleteDoctor(int id)
    {
        await _unitOfWork.Doctors.Delete(id);
        await _unitOfWork.Save();
        return NoContent();
    }

}
