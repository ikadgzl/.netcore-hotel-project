using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelProject.Dto
{
	public class BaseCountryDto
	{
		[Required] public string Name { get; set; }
		[Required] public string ShortName { get; set; }
	}
	
	public class CountryDto : BaseCountryDto
	{
		public int Id { get; set; }
		public  IList<HotelDto> Hotels { get; set; }
		
	}
	
	public class CreateCountryRequest : BaseCountryDto
	{
	}
}