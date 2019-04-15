using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SportConnect.Api.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        [Route("signIn")]
        public async Task<LoginApiModel> SignIn(string login, string password)
        {
            if (login != password)
            {
                return new LoginApiModel
                {
                    IsLogged = true
                };
            }

            return new LoginApiModel();
        }
    }

    public class LoginApiModel
    {
        public bool IsLogged { get; set; }
    }
}
