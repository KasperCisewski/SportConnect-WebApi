using System.Threading.Tasks;
using AutoMapper;
using SportConnect.Core.Repositories;
using SportConnect.Infrastructure.Services.Abstraction;
using System.Linq;
using System;
using SportConnect.Infrastructure.DTO.LoginAndRegistration;
using SportConnect.Infrastructure.DTO.User;
using System.Collections.Generic;
using SportConnect.Core.Domain;

namespace SportConnect.Infrastructure.Services.Implemenation
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public Task<bool> CheckEmailIsExist(string email)
        {
            var emailsInRepository = _userRepository
                .GetAll()
                .Select(u => u.Email);

            return Task.FromResult(emailsInRepository.Contains(email));
        }

        public Task<bool> CheckLoginIsExist(string login)
        {
            var allLoginsInRepository = _userRepository
                .GetAll()
                .Select(u => u.Login).ToList();

            return Task.FromResult(allLoginsInRepository.Contains(login));
        }

        public Task<List<UserModel>> GetExistingUsers()
        {
            var existingUsers = _userRepository
                .GetAll()
                .Where(u => u.IsDeleted == false)
                .Select(u => new UserModel
                {
                    Id = u.Id,
                    Email = u.Email,
                    Login = u.Login
                });

            return Task.FromResult(existingUsers.ToList());
        }

        public async Task<UserProfileModel> GetUserProfileData(Guid userId)
        {
            var user = await _userRepository.GetById(userId);

            return new UserProfileModel
            {
                UserId = user.Id,
                Login = user.Login,
                Email = user.Email,
                FacouriteSportTypeId = user.FavouriteSportTypeId
            };
        }

        public async Task UpdateUserProfile(UserProfileModel userProfileModel)
        {
            var user = await _userRepository.GetById(userProfileModel.UserId);

            user.FavouriteSportTypeId = userProfileModel.FacouriteSportTypeId;
            user.Email = userProfileModel.Email;
            user.Login = userProfileModel.Login;


            await _userRepository.Update(user);
        }

        public Task<LoginApiModel> TryToLoginAndGetData(string login, string password)
        {
            var tryToLoginToAppQuery = _userRepository
                                 .GetAll()
                                 .Where(u =>
                                 (u.Login == login && u.Password == password) ||
                                 (u.Email == login && u.Password == password))
                                 .Select(u => new
                                 {
                                     UserId = u.Id,
                                     UserRoleId = (int)u.RoleId,
                                     u.Login,
                                     u.Email
                                 })
                                 .First();


            if (tryToLoginToAppQuery != null)
            {
                _userRepository.AddNewLogRecord(tryToLoginToAppQuery.UserId);

                var loginApiResult = new LoginApiModel
                {
                    IsSuccess = true,
                    UserRoleId = tryToLoginToAppQuery.UserRoleId,
                    UserId = tryToLoginToAppQuery.UserId,
                    Login = tryToLoginToAppQuery.Login,
                    Email = tryToLoginToAppQuery.Email
                };

                return Task.FromResult(loginApiResult);
            }
            return Task.FromResult(new LoginApiModel());

        }
    }
}