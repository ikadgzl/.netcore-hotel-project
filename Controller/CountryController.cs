using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HotelProject.Dto;
using HotelProject.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HotelProject.Controller
{
	[Route("api/[controller]")]
	[ApiController]
	public class CountryController : ControllerBase
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly ILogger<CountryController> _logger;
		private readonly IMapper _mapper;

		public CountryController(ILogger<CountryController> logger, IUnitOfWork unitOfWork, IMapper mapper)
		{
			_logger = logger;
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<IActionResult> GetCountries()
		{
			try
			{
				var countries = await _unitOfWork.Countries.GetAll();
				var result = _mapper.Map<IList<CountryDto>>(countries);

				return Ok(result);
			}
			catch (Exception e)
			{
				_logger.LogError(e, $"Something went wrong in the {nameof(GetCountries)}");
				return StatusCode(500, "Internal server error.");
			}
		}

		[HttpGet("{id:int}")]
		public async Task<IActionResult> GetCountry(int id)
		{
			try
			{
				var country = await _unitOfWork.Countries.Get(q => q.Id == id, new List<string> {"Hotels"});
				var result = _mapper.Map<CountryDto>(country);

				return Ok(result);
			}
			catch (Exception e)
			{
				_logger.LogError(e, $"Something went wrong in the {nameof(GetCountry)}");
				return StatusCode(500, "Internal server error.");
			}
		}
	}
}