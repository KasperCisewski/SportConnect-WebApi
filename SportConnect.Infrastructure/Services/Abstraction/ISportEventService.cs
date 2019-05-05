using System.Linq;
using System.Threading.Tasks;
using SportConnect.Infrastructure.DTO.SportEvent;

namespace SportConnect.Infrastructure.Services.Abstraction
{
    public interface ISportEventService : IService
    {
        IQueryable<SportEventModel> GetSportEvents(SportEventApiModel sportEventApiModel);
    }
}
