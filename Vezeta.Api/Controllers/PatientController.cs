using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Vezeta.Application.Common;
using Vezeta.Application.Common.Interfaces.Persistance;
using Vezeta.Contract.Dtos.Patient;

namespace Vezeta.Api.Controllers;

[ApiController]
[Route("patient")]

public class PatientController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PatientController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

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
    
}
