using System.Collections.Generic;
using System.Threading.Tasks;
using GrowingPlants.Infrastructure.Models;

namespace GrowingPlants.BusinessLogic.IServices
{
	public interface IHumidityService
	{
		Task<ApiResult<bool>> InsertHumidityList(List<Humidity> humidityList);

		Task<ApiResult<bool>> UpdateHumidity(Humidity humidity);
	}
}
