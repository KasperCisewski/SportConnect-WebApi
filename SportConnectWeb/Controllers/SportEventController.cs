using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportConnect.Infrastructure.DTO.SportEvent;
using SportConnect.Infrastructure.DTO.User;
using SportConnect.Infrastructure.Services.Abstraction;
using static SportConnect.Infrastructure.Services.Implemenation.SportEventService;

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
        public List<SportEventModel> GetSportEvents([FromBody]SportEventApiModel sportEventApiModel)
        {
            return _sportEventService.GetSportEvents(sportEventApiModel);
        }
        [HttpGet]
        [Route("getSportEventsForUser")]
        public List<SportEventModel> GetSportEventsForUser(Guid userId)
        {
            return _sportEventService.GetSportEventsForUser(userId);
        }
        
        [HttpPost]
        [Route("addNewSportEvent")]
        public async Task<string> AddNewSportEvent([FromBody]SportEventApiModelToCreate sportEventApiModelToCreate)
        {
            return await _sportEventService.AddNewSportEvent(sportEventApiModelToCreate);
        }
        [HttpGet]
        [Route("isUserJoinToEvent")]
        public async Task<IsUserAttendedToSportEventModel> IsUserJoinToEvent(Guid id, Guid userId)
        {
            return await _sportEventService.IsUserJoinToEventInPast(id, userId);
        }

        [HttpPut]
        [Route("outFromEvent")]
        public async Task OutFromEvent(Guid id, Guid userId)
        {
            await _sportEventService.UpdateUserSportEvent(id, userId, true);
        }

        [HttpPut]
        [Route("joinToEvent")]
        public async Task JoinToEvent(Guid id, Guid userId)
        {
            await _sportEventService.UpdateUserSportEvent(id, userId, false);
        }
    }
}
