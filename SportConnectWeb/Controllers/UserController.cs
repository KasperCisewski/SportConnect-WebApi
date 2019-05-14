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
            var loginResultModel = await _userService.TryToLoginAndGetUserRoleId(login, password);

            return new LoginApiModel
            {
                IsSuccess = loginResultModel.IsSuccess,
                UserRoleId= loginResultModel.UserRoleId
            };
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
