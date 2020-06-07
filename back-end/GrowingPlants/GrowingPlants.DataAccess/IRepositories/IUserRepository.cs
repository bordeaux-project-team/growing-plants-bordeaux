using System.Threading.Tasks;
using GrowingPlants.Infrastructure.DbModels;

namespace GrowingPlants.DataAccess.IRepositories
{
	public interface IUserRepository : IRepository<User>
	{
		Task<User> FindUserByEmail(string email);
	}
}
