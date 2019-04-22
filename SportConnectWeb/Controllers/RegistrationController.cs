using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportConnect.Infrastructure.DTO;
using SportConnect.Infrastructure.Services.Abstraction;
using SportConnect.Infrastructure.Services.Implemenation;

namespace SportConnect.Api.Controllers
{
    [Route("api/registration")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IRegistrationService _registrationService;

        public RegistrationController(IRegistrationService registrationService)
        {
            _registrationService = registrationService;
        }

        [HttpPost]
        [Route("register")]
        public async Task<bool> Register([FromBody]RegistrationResponseApiModel registrationResponseApiModel)
        {
            return await _registrationService.Register(registrationResponseApiModel);
        }
    }
}
