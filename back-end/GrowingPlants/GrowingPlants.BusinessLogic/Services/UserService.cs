using System;
using System.Threading.Tasks;
using GrowingPlants.BusinessLogic.IServices;
using GrowingPlants.BusinessLogic.UnitOfWorks;
using GrowingPlants.Infrastructure.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace GrowingPlants.BusinessLogic.Services
{
	public class UserService : IUserService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly ILogger _logger;
		public UserService(ILoggerFactory loggerFactory, IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
			_logger = loggerFactory.CreateLogger(typeof(UserService));
		}

		/// <summary>
		/// Check if username exists
		/// If not => Hash password and insert user
		/// Else return error
		/// </summary>
		/// <param name="user"></param>
		/// <returns></returns>
		public async Task<bool> Register(User user)
		{
			if (user == null)
			{
				throw new ArgumentException("User is null");
			}
			_logger.LogInformation($"User registration: {JsonConvert.SerializeObject(user)}");

			await _unitOfWork.UserRepository.Insert(user);

			return true;
		}
	}
}
