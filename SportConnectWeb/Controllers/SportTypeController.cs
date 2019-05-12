using Microsoft.AspNetCore.Mvc;
using SportConnect.Core.Domain;
using SportConnect.Infrastructure.Services.Abstraction;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportConnect.Api.Controllers
{
    [Route("api/sportType")]
    [ApiController]
    public class SportTypeController : ControllerBase
    {
        private readonly ISportTypeService _sportTypeService;

        public SportTypeController(ISportTypeService sportTypeService)
        {
            _sportTypeService = sportTypeService;
        }

        [HttpGet]
        [Route("getSportTypes")]
        public async Task<List<SportType>> GetSportTypesAsync()
        {
            return await _sportTypeService.GetSportTypes();
        }
    }
}