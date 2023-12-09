using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Vezeta.Application.Common;
using Vezeta.Application.Common.Interfaces.Persistance;
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



    //Dashboard

    //Top 5 Specializations

    //Top 10 Doctors
}