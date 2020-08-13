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
        IPlantingEnvironmentRepository PlantingEnvironmentRepository { get; set; }
        ICountryRepository CountryRepository { get; set; }
        IPlantingProcessRepository PlantingProcessRepository { get; set; }
        IProcessStepRepository ProcessStepRepository { get; set; }
        IPlantingActionRepository PlantingActionRepository { get; set; }
        IRecurrenceRepository RecurrenceRepository { get; set; }
        INotificationRepository NotificationRepository { get; set; }
        IPlantingSpotRepository PlantingSpotRepository { get; set; }
        IPlantTypeRepository PlantTypeRepository { get; set; }
        IGalleryRepository GalleryRepository { get; set; }
        IPictureRepository PictureRepository { get; set; }
    }
}
