using Microsoft.AspNetCore.Mvc;
using Vezeta.Application.Common;
using Vezeta.Application.Common.Interfaces.Persistance;
using Vezeta.Application.Services.Authentication;
using Vezeta.Contract.Authentication;

namespace Vezeta.Api.Controllers;


[ApiController]
[Route("admin")]
public class AdminController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public AdminController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    //Doctors

    [HttpGet("doctors")]
    public async Task<IActionResult> GetDoctors([FromQuery] RequestParams requestParams)
    {
        var doctors = await _unitOfWork.Doctors.GetPagedList(requestParams);

        //map to dto
        return Ok(doctors);
    }


    [HttpGet("id:int", Name = "GetDoctor")]
    public async Task<IActionResult> GetDoctor(int id)
    {
        var doctor = await _unitOfWork.Doctors.GetById(id);

        //map to dto
        return Ok(doctor);
    }

    [HttpPost("AddDoctor")]
    public async Task<IActionResult> AddDoctor()
    {

    }












    //Patients
    //Dashboard
}