using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using GrowingPlants.BusinessLogic.IServices;
using GrowingPlants.BusinessLogic.UnitOfWorks;
using GrowingPlants.Infrastructure.Models;
using GrowingPlants.Infrastructure.Utilities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using DateTime = System.DateTime;

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
        public async Task<ApiResult<bool>> RegisterAccount(User user)
        {
            if (user == null) throw new ArgumentException("User is null");
            if (string.IsNullOrEmpty(user.Email)) throw new ArgumentException("Email is null");
            if (string.IsNullOrEmpty(user.Password)) throw new ArgumentException("Password is null");

            _logger.LogInformation($"User registration: {JsonConvert.SerializeObject(user)}");

            var existingUser = await _unitOfWork.UserRepository.FindUserByEmail(user.Email);
            if (existingUser != null)
            {
                return new ApiResult<bool>
                {
                    ApiCode = ApiCode.UserExisted,
                    Result = false
                };
            }

            user.Password = HashPassword(user.Password);
            user.CreatedAt = DateTime.UtcNow;

            if (string.IsNullOrEmpty(user.Role))
            {
                user.Role = Constants.UserRole.Client;
            }

            user.Status = true;

            var canInsert = await _unitOfWork.UserRepository.Insert(user);
            if (!canInsert) throw new Exception("Cannot insert new user into database");

            return new ApiResult<bool>
            {
                Result = true,
                ApiCode = ApiCode.Success
            };
        }

        public async Task<ApiResult<User>> Login(LoginCredential loginCredential)
        {
            if (loginCredential == null || 
                string.IsNullOrEmpty(loginCredential.Email) ||
                string.IsNullOrEmpty(loginCredential.Password))
            {
                return new ApiResult<User>
                {
                    ApiCode = ApiCode.BadCredential,
                    Result = null
                };
            }

            var user = await _unitOfWork.UserRepository.FindUserByEmail(loginCredential.Email);
            if (user == null)
            {
                return new ApiResult<User>
                {
                    ApiCode = ApiCode.BadCredential,
                    Result = null
                };
            }

            var hashedPassword = HashPassword(loginCredential.Password);
            if (hashedPassword != user.Password)
            {
                return new ApiResult<User>
                {
                    ApiCode = ApiCode.BadCredential,
                    Result = null
                };
            }

            user.Token = GenerateToken(user);
            return new ApiResult<User>
            {
                Result = user,
                ApiCode = ApiCode.Success
            };
        }

        private string GenerateToken(User user)
        {
            var secretKey = Encoding.ASCII.GetBytes(_configuration["Secret"]);
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()), 
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddDays(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha256Signature)
            };

            return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
        }

        private static string HashPassword(string password)
        {
            var data = Encoding.ASCII.GetBytes(password);
            data = new SHA256Managed().ComputeHash(data);
            var hashedPassword = Encoding.ASCII.GetString(data);
            return hashedPassword;
        }
    }
}
