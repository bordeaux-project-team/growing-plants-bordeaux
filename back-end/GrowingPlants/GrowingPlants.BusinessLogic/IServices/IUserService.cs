using System.Threading.Tasks;
using GrowingPlants.Infrastructure.ApiModels;
using GrowingPlants.Infrastructure.DbModels;

namespace GrowingPlants.BusinessLogic.IServices
{
	public interface IUserService
	{
		public Task<ApiResult<UserLogin>> Login(LoginCredential loginCredential);
		public Task<ApiResult<bool>> Register(User user);
	}
}
