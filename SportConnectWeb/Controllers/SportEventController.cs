using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportConnect.Infrastructure.DTO.SportEvent;
using SportConnect.Infrastructure.Services.Abstraction;

namespace SportConnect.Api.Controllers
{
    [Route("api/sportEvent")]
    [ApiController]
    public class SportEventController : ControllerBase
    {
        private readonly ISportEventService _sportEventService;

        public SportEventController(ISportEventService sportEventService)
        {
            _sportEventService = sportEventService;
        }

        [HttpPost]
        [Route("getSportEvents")]
        public List<SportEventModel> GetSportEvents([FromBody]SportEventApiModel registrationResponseApiModel)
        {
           return _sportEventService.GetSportEvents(registrationResponseApiModel);
        }

        [HttpPost]
        [Route("addNewSportEvent")]
        public async Task<string> AddNewSportEvent([FromBody]SportEventApiModelToCreate sportEventApiModelToCreate)
        {
            return await _sportEventService.AddNewSportEvent(sportEventApiModelToCreate);
        }
    }
}
