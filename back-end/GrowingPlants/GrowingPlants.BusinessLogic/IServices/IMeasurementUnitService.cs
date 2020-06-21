using GrowingPlants.Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GrowingPlants.BusinessLogic.IServices
{
    public interface IMeasurementUnitService
    {
        Task<ApiResult<bool>> InsertMeasurementUnits(List<MeasurementUnit> measurementUnits);

        Task<ApiResult<bool>> UpdateMeasurementUnit(MeasurementUnit measurementUnit);
    }
}
