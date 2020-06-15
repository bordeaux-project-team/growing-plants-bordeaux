using System.Collections.Generic;
using System.Threading.Tasks;
using GrowingPlants.Infrastructure.Models;

namespace GrowingPlants.BusinessLogic.IServices
{
	public interface ITemperatureService
	{
		Task<ApiResult<bool>> InsertTemperatures(List<Temperature> temperatures);

		Task<ApiResult<bool>> UpdateTemperature(Temperature temperature);
	}
}
