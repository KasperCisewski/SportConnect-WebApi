using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportConnect.Infrastructure.DTO.SportEvent;

namespace SportConnect.Infrastructure.Services.Abstraction
{
    public interface ISportEventService : IService
    {
        List<SportEventModel> GetSportEvents(SportEventApiModel sportEventApiModel);
    }
}
