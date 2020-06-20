using GrowingPlants.BusinessLogic.IServices;
using GrowingPlants.BusinessLogic.UnitOfWorks;
using Microsoft.Extensions.Logging;

namespace GrowingPlants.BusinessLogic.Services
{
    public class CountryService : ICountryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;

        public CountryService(ILoggerFactory loggerFactory, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _logger = loggerFactory.CreateLogger(typeof(CountryService));
        }
    }
}
