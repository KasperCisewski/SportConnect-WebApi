using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SportConnect.Infrastructure.DTO.LoginAndRegistration;
using SportConnect.Infrastructure.DTO.User;

namespace SportConnect.Infrastructure.Services.Abstraction
{
    public interface IUserService : IService
    {
        Task<LoginApiModel> TryToLoginAndGetData(string login, string password);
        Task<bool> CheckEmailIsExist(string email);
        Task<bool> CheckLoginIsExist(string login);
        Task<List<UserModel>> GetExistingUsers();
        Task<UserProfileModel> GetUserProfileData(Guid userId);
        Task UpdateUserProfile(UserProfileModel userProfileModel);
        Task<List<UserLogRecordModel>> GetUsersLogRecords();
    }
}
