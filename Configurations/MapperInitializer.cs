using AutoMapper;
using HotelProject.Data;
using HotelProject.Dto;

namespace HotelProject.Configurations
{
	public class MapperInitializer : Profile
	{
		public MapperInitializer()
		{
			CreateMap<Country, CountryDto>().ReverseMap();
			CreateMap<Country, CreateCountryRequest>().ReverseMap();
			
			
			CreateMap<Hotel, HotelDto>().ReverseMap();
			CreateMap<Hotel, CreateHotelRequest>().ReverseMap();
		}
	}
}