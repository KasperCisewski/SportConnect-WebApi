using System.Threading.Tasks;
using SportConnect.Infrastructure.DTO;

namespace SportConnect.Infrastructure.Services.Abstraction
{
    public interface IRegistrationService : IService
    {
        Task<bool> Register(RegistrationResponseApiModel registrationResponseApiModel);
    }
}
