using GrowingPlants.DataAccess.IRepositories;

namespace GrowingPlants.BusinessLogic.UnitOfWorks
{
	public interface IUnitOfWork
	{
		IUserRepository UserRepository { get; set; }
		ITreeRepository TreeRepository { get; set; }
	}
}
