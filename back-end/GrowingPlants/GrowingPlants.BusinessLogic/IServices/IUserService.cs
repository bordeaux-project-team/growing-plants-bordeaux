using System.Threading.Tasks;
using GrowingPlants.Infrastructure.Models;

namespace GrowingPlants.BusinessLogic.IServices
{
	public interface IUserService
	{
		public Task<User> Login(string username, string password);
		public Task<bool> Register(User user);
	}
}
