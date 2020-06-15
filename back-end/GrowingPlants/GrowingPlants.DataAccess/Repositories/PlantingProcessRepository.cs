using GrowingPlants.DataAccess.Context;
using GrowingPlants.DataAccess.IRepositories;
using GrowingPlants.Infrastructure.Models;

namespace GrowingPlants.DataAccess.Repositories
{
	public class PlantingProcessRepository : Repository<PlantingProcess>, IPlantingProcessRepository
	{
		public PlantingProcessRepository(GrowingPlantsContext context) : base(context)
		{
		}
	}
}
