using GrowingPlants.DataAccess.Context;
using GrowingPlants.DataAccess.IRepositories;
using GrowingPlants.DataAccess.Repositories;

namespace GrowingPlants.BusinessLogic.UnitOfWorks
{
	public class UnitOfWork : IUnitOfWork
	{
		public IUserRepository UserRepository { get; set; }
		public ITreeRepository TreeRepository { get; set; }
		public IMeasurementUnitRepository MeasurementUnitRepository { get; set; }
		public ILightRepository LightRepository { get; set; }
		public IHumidityRepository HumidityRepository { get; set; }
		public ITemperatureRepository TemperatureRepository { get; set; }

		public UnitOfWork(GrowingPlantsContext context)
		{
			UserRepository = new UserRepository(context);
			TreeRepository = new TreeRepository(context);
			MeasurementUnitRepository = new MeasurementUnitRepository(context);
			LightRepository = new LightRepository(context);
			HumidityRepository = new HumidityRepository(context);
			TemperatureRepository = new TemperatureRepository(context);
		}
	}
}
