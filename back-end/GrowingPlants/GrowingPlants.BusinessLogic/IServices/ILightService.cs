using System.Collections.Generic;
using System.Threading.Tasks;
using GrowingPlants.Infrastructure.Models;

namespace GrowingPlants.BusinessLogic.IServices
{
	public interface ILightService
	{
		Task<ApiResult<bool>> InsertLights(List<Light> lights);

		Task<ApiResult<bool>> UpdateLight(Light light);
	}
}
