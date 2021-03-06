﻿using GrowingPlants.Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GrowingPlants.BusinessLogic.IServices
{
    public interface IUserService
    {
        public Task<ApiResult<User>> Login(LoginCredential loginCredential);
        public Task<ApiResult<bool>> RegisterAccount(User user);
        Task<ApiResult<bool>> UpdateUser(User user);
        Task<ApiResult<bool>> UpdateUserStatus(int id, bool status);
        Task<ApiResult<bool>> ChangePassword(NewPassword newPassword);
        Task<ApiResult<User>> GoogleLogin(LoginCredential loginCredential);
        Task<ApiResult<bool>> ForgotPassword();
        Task<ApiResult<List<User>>> GetAll();
    }
}
