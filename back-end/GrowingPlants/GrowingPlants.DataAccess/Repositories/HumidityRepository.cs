using GrowingPlants.DataAccess.Context;
using GrowingPlants.DataAccess.IRepositories;
using GrowingPlants.Infrastructure.Models;

namespace GrowingPlants.DataAccess.Repositories
{
	public class HumidityRepository : Repository<Humidity>, IHumidityRepository
	{
		public HumidityRepository(GrowingPlantsContext context) : base(context)
		{
		}
	}
}
