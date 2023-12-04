using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Vezeta.Application.Common;
using Vezeta.Application.Common.Interfaces.Persistance;
using Vezeta.Application.Services.Authentication;
using Vezeta.Contract.Dtos.Admin;
using Vezeta.Contract.Authentication;
using Vezeta.Domain.Entities;

namespace Vezeta.Api.Controllers;


[ApiController]
[Route("admin")]
public class AdminController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public AdminController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    //Doctors

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
        await _unitOfWork.Doctors.Insert(doctor);
        await _unitOfWork.Save();
        //var result = _mapper.Map<GetDoctorDto>(doctor);
        return Ok(doctorDto);
    }

    [HttpPut("id:int", Name ="UpdateDoctor")]
    public async Task<IActionResult> UpdateDoctor(int id, [FromBody] UpdateDoctorDto doctorDto)
    {
        var doctor = await _unitOfWork.Doctors.Get(q => q.Id == id);
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

    //Patients
    [HttpGet("patients")]
    public async Task<IActionResult> GetPatients([FromQuery] RequestParams requestParams)
    {
        var patients = await _unitOfWork.Patients.GetPagedList(requestParams, new List<string> { "Bookings","Invoices" });
        var result = _mapper.Map<List<GetPatientDto>>(patients);
        return Ok(result);
    }

    [HttpGet("patient/{id:int}")]
    public async Task<IActionResult> GetPatient(int id)
    {
        var patient = await _unitOfWork.Patients.Get(q => q.Id == id, new List<string> { "Bookings", "Invoices" });
        var result = _mapper.Map<GetPatientDto>(patient);
        return Ok(result);
    }


    //Dashboard

    //NumOfDoctors

    //NumOfPatients

    //NumOfBookings

    //Top 5 Specializations

    //Top 10 Doctors
}