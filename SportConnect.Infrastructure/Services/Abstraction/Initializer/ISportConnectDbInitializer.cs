using System.Threading.Tasks;

namespace SportConnect.Infrastructure.Services.Abstraction.Initializer
{
    public interface ISportConnectDbInitializer : IService
    {
        Task<bool> Initialize();
    }
}