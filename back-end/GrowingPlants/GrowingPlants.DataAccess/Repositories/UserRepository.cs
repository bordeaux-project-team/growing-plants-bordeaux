using GrowingPlants.DataAccess.Context;
using GrowingPlants.DataAccess.IRepositories;
using GrowingPlants.Infrastructure.Models;

namespace GrowingPlants.DataAccess.Repositories
{
	public class UserRepository : Repository<User>, IUserRepository
	{
		public UserRepository(GrowingPlantsContext context) : base(context)
		{
		}
	}
}
