using System.Threading.Tasks;
using GrowingPlants.Infrastructure.Models;

namespace GrowingPlants.BusinessLogic.IServices
{
	public interface IUserService
	{
		public Task<bool> Register(User user);
	}
}
