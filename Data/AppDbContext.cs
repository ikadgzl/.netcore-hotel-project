using Microsoft.EntityFrameworkCore;

namespace HotelProject.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Country>().HasData(
				new Country()
				{
					Id = 1,
					Name = "Turkey",
					ShortName = "TR"
				},
				new Country()
				{
					Id = 2,
					Name = "Germany",
					ShortName = "GER"
				},
				new Country()
				{
					Id = 3,
					Name = "France",
					ShortName = "FR"
				}
			);
			
			modelBuilder.Entity<Hotel>().HasData(
				new Hotel()
				{
					Id = 1,
					Name = "Hotel in Turkey",
					Address = "Hotel in Turkey, some address, 21, 12",
					CountryId = 1,
					Rating = 7.3
				},
				new Hotel()
				{
					Id = 2,
					Name = "Hotel in Germany",
					Address = "Hotel in Germany, some address, 21, 12",
					CountryId = 2,
					Rating = 9
				},
				new Hotel()
				{
					Id = 3,
					Name = "Hotel in France",
					Address = "Hotel in France, some address, 21, 12",
					CountryId = 3,
					Rating = 4.3
				}
			);
		}

		public DbSet<Country> Countries { get; set; }
		public DbSet<Hotel> Hotels { get; set; }
	}
}