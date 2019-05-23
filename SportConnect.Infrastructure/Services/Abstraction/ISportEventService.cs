using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SportConnect.Infrastructure.DTO.SportEvent;
using SportConnect.Infrastructure.DTO.User;

namespace SportConnect.Infrastructure.Services.Abstraction
{
    public interface ISportEventService : IService
    {
        List<SportEventModel> GetSportEvents(SportEventApiModel sportEventApiModel);
        Task<string> AddNewSportEvent(SportEventApiModelToCreate sportEventApiModelToCreate);
        Task UpdateUserSportEvent(Guid id, Guid userId, bool isDeleteFromConfirmedParticipants);
        Task<IsUserAttendedToSportEventModel> IsUserJoinToEventInPast(Guid id, Guid userId);
        List<SportEventModel> GetSportEventsForUser(Guid userId);
    }
}
