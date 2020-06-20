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
        public IFavoriteTreeRepository FavoriteTreeRepository { get; set; }
        public IPlantingEnvironmentRepository PlantingEnvironmentRepository { get; set; }
        public ICountryRepository CountryRepository { get; set; }
        public IPlantingProcessRepository PlantingProcessRepository { get; set; }
        public IProcessStepRepository ProcessStepRepository { get; set; }
        public IPlantingActionRepository PlantingActionRepository { get; set; }
        public IRecurrenceRepository RecurrenceRepository { get; set; }
        public INotificationRepository NotificationRepository { get; set; }
        public IGardenRepository GardenRepository { get; set; }

        public UnitOfWork(GrowingPlantsContext context)
        {
            UserRepository = new UserRepository(context);
            TreeRepository = new TreeRepository(context);
            MeasurementUnitRepository = new MeasurementUnitRepository(context);
            LightRepository = new LightRepository(context);
            HumidityRepository = new HumidityRepository(context);
            TemperatureRepository = new TemperatureRepository(context);
            FavoriteTreeRepository = new FavoriteTreeRepository(context);
            CountryRepository = new CountryRepository(context);
            PlantingProcessRepository = new PlantingProcessRepository(context);
            PlantingEnvironmentRepository = new PlantingEnvironmentRepository(context);
            ProcessStepRepository = new ProcessStepRepository(context);
            PlantingActionRepository = new PlantingActionRepository(context);
            RecurrenceRepository = new RecurrenceRepository(context);
            NotificationRepository = new NotificationRepository(context);
            GardenRepository = new GardenRepository(context);
        }
    }
}
