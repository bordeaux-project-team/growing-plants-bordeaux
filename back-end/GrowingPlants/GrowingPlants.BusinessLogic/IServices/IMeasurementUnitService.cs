using System.Collections.Generic;
using System.Threading.Tasks;
using GrowingPlants.Infrastructure.Models;

namespace GrowingPlants.BusinessLogic.IServices
{
    public interface IMeasurementUnitService
    {
        Task<ApiResult<bool>> InsertMeasurementUnits(List<MeasurementUnit> measurementUnits);

        Task<ApiResult<bool>> UpdateMeasurementUnit(MeasurementUnit measurementUnit);
    }
}
