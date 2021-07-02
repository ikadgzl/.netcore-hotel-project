using System.ComponentModel.DataAnnotations;

namespace HotelProject.Dto
{
	public class BaseHotelDto
	{
		[Required] public string Name { get; set; }

		[Required] public string Address { get; set; }

		[Required] public double Rating { get; set; }

		[Required] public int CountryId { get; set; }
	}

	public class HotelDto : BaseHotelDto
	{
		public int Id { get; set; }
		public CountryDto Country { get; set; }
	}

	public class CreateHotelRequest : BaseHotelDto
	{
		
	}
}