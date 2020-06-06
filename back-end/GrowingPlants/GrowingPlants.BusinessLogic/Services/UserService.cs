using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using GrowingPlants.BusinessLogic.IServices;
using GrowingPlants.BusinessLogic.UnitOfWorks;
using GrowingPlants.Infrastructure.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace GrowingPlants.BusinessLogic.Services
{
	public class UserService : IUserService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IConfiguration _configuration;
		private readonly ILogger _logger;
		public UserService(ILoggerFactory loggerFactory, IUnitOfWork unitOfWork, IConfiguration configuration)
		{
			_unitOfWork = unitOfWork;
			_configuration = configuration;
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

			var secretKey = Encoding.ASCII.GetBytes(_configuration["Secret"]);
			var tokenHandler = new JwtSecurityTokenHandler();
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new[]
				{
					new Claim(ClaimTypes.Name, user.Email)
				}),
				Expires = DateTime.UtcNow.AddDays(1),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha256Signature)
			};

			var token = tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
			await _unitOfWork.UserRepository.Insert(user);

			return true;
		}

		public Task<User> Login(string username, string password)
		{
			throw new NotImplementedException();
		}
	}
}
