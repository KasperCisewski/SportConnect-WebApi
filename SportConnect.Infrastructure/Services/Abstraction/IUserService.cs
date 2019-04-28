using System.Threading.Tasks;
using SportConnect.Infrastructure.Dto;

namespace SportConnect.Infrastructure.Services.Abstraction
{
    public interface IUserService : IService
    {
        Task<UserDto> Get(string email);
        bool TryToLogin(string login, string password);
    }
}
