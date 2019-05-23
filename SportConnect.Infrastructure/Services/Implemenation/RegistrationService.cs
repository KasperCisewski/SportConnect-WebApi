using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SportConnect.Core.Domain;
using SportConnect.Core.Repositories;
using SportConnect.Infrastructure.DTO.LoginAndRegistration;
using SportConnect.Infrastructure.Repositories;
using SportConnect.Infrastructure.Services.Abstraction;

namespace SportConnect.Infrastructure.Services.Implemenation
{
    public class RegistrationService : IRegistrationService
    {
        private readonly IUserRepository _userRepository;
        private readonly ISportTypeRepository _sportTypeRepository;
        private readonly IMapper _mapper;
        public RegistrationService(
            IUserRepository userRepository,
            ISportTypeRepository sportTypeRepository,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _sportTypeRepository = sportTypeRepository;
            _mapper = mapper;
        }
        public async Task<bool> Register(RegistrationResponseApiModel registrationResponseApiModel)
        {
            await _userRepository.Add(new User
            {
                Email = registrationResponseApiModel.Email,
                Login = registrationResponseApiModel.Login,
                Password = registrationResponseApiModel.Password,
                RoleId = (int)Core.Enums.Role.Normal,
                FavouriteSportTypeId = _sportTypeRepository.GetAll().FirstOrDefault().Id
            });

            return _userRepository.GetAll().Any(u =>
                u.Login == registrationResponseApiModel.Login && u.Email == registrationResponseApiModel.Email);
        }
    }
}
