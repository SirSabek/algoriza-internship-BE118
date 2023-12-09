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
    private readonly List<string> _allowedExtensions = new() { ".jpg", ".png", ".jpeg" };
    private long _fileSizeLimit = 1024 * 1024 * 5; //5MB

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
    public async Task<IActionResult> AddDoctor([FromForm] AddDoctorDto doctorDto)
    {
        if (!IsSuitableImage(doctorDto.Image))
        {
            return BadRequest("Image can't be more than 5MB or not a 'jpg', 'png', 'jpeg'");
        }

        using var dataStream = new MemoryStream();

        await doctorDto.Image.CopyToAsync(dataStream);

        var doctor = _mapper.Map<Doctor>(doctorDto);
        
        doctor.Image = dataStream.ToArray();

        doctor.UserName = doctorDto.Email;
        await _userManager.CreateAsync(doctor, doctorDto.Password);
        await _unitOfWork.Save();
        return Ok(doctorDto);
    }
    

    [HttpPut("id:int", Name ="UpdateDoctor")]
    public async Task<IActionResult> UpdateDoctor([FromForm] UpdateDoctorDto doctorDto)
    {
        if (!IsSuitableImage(doctorDto.Image))
        {
            return BadRequest("Image can't be more than 5MB or not a 'jpg', 'png', 'jpeg'");
        }
        using var dataStream = new MemoryStream();
        await doctorDto.Image.CopyToAsync(dataStream);
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

    [HttpGet("count")]
    public async Task<IActionResult> GetDoctorsCount()
    {
        var count = await _unitOfWork.Doctors.GetAll();
        return Ok(count.Count());
    }

   
    [HttpGet("topSpecializations")]
    public async Task<IActionResult> GetTopSpecializations()
    {
        var topSpecializations = await _unitOfWork.Doctors.GetTopDoctorSpecializations();
        return Ok(topSpecializations);
    }
    
    [HttpGet("topDoctors")]
    public async Task<IActionResult> GetTopDoctors()
    {
        var topDoctors = await _unitOfWork.Doctors.GetTopDoctors();
        return Ok(topDoctors);
    }
    
    [HttpGet("doctorsSchedule")]
    public async Task<IActionResult> GetAllDoctorsSchedule()
    {
        var doctorsSchedule = await _unitOfWork.Doctors.GetAllDoctorsSchedule();
        return Ok(doctorsSchedule);
    }
    private bool IsSuitableImage(IFormFile file)
    {
        var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
        return _allowedExtensions.Any(x => x == extension) && file.Length < _fileSizeLimit;
    }
}
