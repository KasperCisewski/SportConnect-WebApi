﻿using System.Threading.Tasks;
using SportConnect.Infrastructure.DTO;

namespace SportConnect.Infrastructure.Services.Abstraction
{
    public interface IUserService : IService
    {
        Task<LoginApiModel> TryToLoginAndGetUserRoleId(string login, string password);
        Task<bool> CheckEmailIsExist(string email);
        Task<bool> CheckLoginIsExist(string login);
    }
}
