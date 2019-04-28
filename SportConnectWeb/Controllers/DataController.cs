using Microsoft.AspNetCore.Mvc;
using SportConnect.Infrastructure.Services.Abstraction.Initializer;

namespace SportConnect.Api.Controllers
{
    [Route("api/data")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly ISportConnectDbInitializer _sportConnectDbInitializer;

        public DataController(ISportConnectDbInitializer sportConnectDbInitializer)
        {
            _sportConnectDbInitializer = sportConnectDbInitializer;
        }

        [HttpGet]
        [Route("initialize")]
        public bool InitializeDatabase()
        {
            return _sportConnectDbInitializer.Initialize().Result;
        }
    }
}
