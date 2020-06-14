using GrowingPlants.DataAccess.Context;
using GrowingPlants.DataAccess.IRepositories;
using GrowingPlants.DataAccess.Repositories;

namespace GrowingPlants.BusinessLogic.UnitOfWorks
{
	public class UnitOfWork : IUnitOfWork
	{
		public IUserRepository UserRepository { get; set; }

		public UnitOfWork(GrowingPlantsContext context)
		{
			UserRepository = new UserRepository(context);
		}
	}
}
