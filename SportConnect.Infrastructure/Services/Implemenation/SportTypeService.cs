using SportConnect.Core.Domain;
using SportConnect.Core.Repositories;
using SportConnect.Infrastructure.Services.Abstraction;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportConnect.Infrastructure.Services.Implemenation
{
    public class SportTypeService : ISportTypeService
    {
        private readonly ISportTypeRepository _sportTypeRepository;

        public SportTypeService(ISportTypeRepository sportTypeRepository)
        {
            _sportTypeRepository = sportTypeRepository;
        }

        public IQueryable<SportType> GetSportTypes()
        {
            return _sportTypeRepository.GetAll();
        }

        Task<List<SportType>> ISportTypeService.GetSportTypes()
        {
            return Task.FromResult(_sportTypeRepository.GetAll().ToList());
        }
    }
}
