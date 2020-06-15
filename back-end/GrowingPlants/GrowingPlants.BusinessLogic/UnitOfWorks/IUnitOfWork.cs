using GrowingPlants.DataAccess.IRepositories;

namespace GrowingPlants.BusinessLogic.UnitOfWorks
{
	public interface IUnitOfWork
	{
		IUserRepository UserRepository { get; set; }
		ITreeRepository TreeRepository { get; set; }
		IMeasurementUnitRepository MeasurementUnitRepository { get; set; }
		ILightRepository LightRepository { get; set; }
		IHumidityRepository HumidityRepository { get; set; }
		ITemperatureRepository TemperatureRepository { get; set; }
		IFavoriteTreeRepository FavoriteTreeRepository { get; set; }
	}
}
