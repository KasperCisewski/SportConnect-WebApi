using SportConnect.Core.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportConnect.Infrastructure.Services.Abstraction
{
    public interface ISportTypeService : IService
    {
        Task<List<SportType>> GetSportTypes();
    }
}