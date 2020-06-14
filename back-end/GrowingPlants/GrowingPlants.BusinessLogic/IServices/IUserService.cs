using System.Threading.Tasks;
using GrowingPlants.Infrastructure.Models;

namespace GrowingPlants.BusinessLogic.IServices
{
	public interface IUserService
	{
		public Task<ApiResult<User>> Login(LoginCredential loginCredential);
		public Task<ApiResult<bool>> RegisterAccount(User user);
	}
}
