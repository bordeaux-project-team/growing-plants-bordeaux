using GrowingPlants.DataAccess.Context;
using GrowingPlants.DataAccess.IRepositories;
using GrowingPlants.Infrastructure.Models;

namespace GrowingPlants.DataAccess.Repositories
{
	public class LightRepository : Repository<Light>, ILightRepository
	{
		public LightRepository(GrowingPlantsContext context) : base(context)
		{
		}
	}
}
