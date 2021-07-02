using System;
using System.Threading.Tasks;
using HotelProject.Data;

namespace HotelProject.IRepository
{
	public interface IUnitOfWork : IDisposable
	{
		IGenericRepository<Country> Countries { get; }
		IGenericRepository<Hotel> Hotels { get; }
		Task Save();

	}
}