using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportConnect.Infrastructure.DTO.LoginAndRegistration;
using SportConnect.Infrastructure.DTO.User;
using SportConnect.Infrastructure.Services.Abstraction;

namespace SportConnect.Api.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("signIn")]
        public async Task<LoginApiModel> SignIn(string login, string password)
        {
            return await _userService.TryToLoginAndGetData(login, password);
        }

        [HttpGet]
        [Route("isEmailExist")]
        public async Task<EmailExistApiModel> IsEmailExist(string email)
        {
            var isExist = await _userService.CheckEmailIsExist(email);

            return new EmailExistApiModel
            {
                IsExist = isExist
            };
        }

        [HttpGet]
        [Route("isLoginExist")]
        public async Task<LoginExistApiModel> IsLoginExist(string login)
        {
            var isExist = await _userService.CheckLoginIsExist(login);

            return new LoginExistApiModel
            {
                IsExist = isExist
            };
        }

        [HttpGet]
        [Route("getUserProfileData")]
        public async Task<UserProfileModel> GetProfileData(Guid userId)
        {
            return await _userService.GetUserProfileData(userId);
        }

        [HttpPut]
        [Route("updateUserProfileData")]
        public async Task UpdateUserProfileData([FromBody]UserProfileModel userProfileModel)
        {
            await _userService.UpdateUserProfile(userProfileModel);
        }

        [HttpGet]
        [Route("getExistingUsers")]
        public async Task<List<UserModel>> GetExistingUsers()
        {
            return await _userService.GetExistingUsers();
        }
    }

    public class LoginExistApiModel
    {
        public bool IsExist { get; set; }
    }

    public class EmailExistApiModel
    {
        public bool IsExist { get; set; }
    }
}
