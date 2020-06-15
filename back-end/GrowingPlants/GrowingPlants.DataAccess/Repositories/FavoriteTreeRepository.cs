using GrowingPlants.DataAccess.Context;
using GrowingPlants.DataAccess.IRepositories;
using GrowingPlants.Infrastructure.Models;

namespace GrowingPlants.DataAccess.Repositories
{
	public class FavoriteTreeRepository : Repository<FavoriteTree>, IFavoriteTreeRepository
	{
		public FavoriteTreeRepository(GrowingPlantsContext context) : base(context)
		{
		}
	}
}
