using System.Threading.Tasks;
using SportConnect.Infrastructure.DTO.LoginAndRegistration;

namespace SportConnect.Infrastructure.Services.Abstraction
{
    public interface IRegistrationService : IService
    {
        Task<bool> Register(RegistrationResponseApiModel registrationResponseApiModel);
    }
}
