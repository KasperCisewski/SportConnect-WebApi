using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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

            var tryToLogInToApp = _userService.TryToLogin(login, password);

            return new LoginApiModel
            {
                IsLogged = tryToLogInToApp
            };
        }

        [HttpGet]
        [Route("isEmailExist")]
        public async Task<EmailExistApiModel> IsEmailExist(string email)
        {
            return new EmailExistApiModel
            {
                IsExist = true
            };
        }

        [HttpGet]
        [Route("isLoginExist")]
        public async Task<LoginExistApiModel> IsLoginExist(string login)
        {
            return new LoginExistApiModel
            {
                IsExist = true
            };
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

    public class LoginApiModel
    {
        public bool IsLogged { get; set; }
    }
}
