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
	public class HotelController : ControllerBase
	{
		
		private readonly IUnitOfWork _unitOfWork;
		private readonly ILogger<CountryController> _logger;
		private readonly IMapper _mapper;

		public HotelController(ILogger<CountryController> logger, IUnitOfWork unitOfWork, IMapper mapper)
		{
			_logger = logger;
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<IActionResult> GetHotels()
		{
			try
			{
				var hotels = await _unitOfWork.Hotels.GetAll();
				var result = _mapper.Map<IList<HotelDto>>(hotels);

				return Ok(result);
			}
			catch (Exception e)
			{
				_logger.LogError(e, $"Something went wrong in the {nameof(GetHotels)}");
				return StatusCode(500, "Internal server error.");
			}
		}

		[HttpGet("{id:int}")]
		public async Task<IActionResult> GetHotel(int id)
		{
			try
			{
				var hotel = await _unitOfWork.Hotels.Get(q => q.Id == id, new List<string> {"Country"});
				var result = _mapper.Map<HotelDto>(hotel);

				return Ok(result);
			}
			catch (Exception e)
			{
				_logger.LogError(e, $"Something went wrong in the {nameof(GetHotel)}");
				return StatusCode(500, "Internal server error.");
			}
		}
	}
}