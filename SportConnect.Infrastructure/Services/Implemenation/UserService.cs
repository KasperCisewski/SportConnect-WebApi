using System.Threading.Tasks;
using AutoMapper;
using SportConnect.Core.Domain;
using SportConnect.Core.Repositories;
using SportConnect.Infrastructure.Dto;
using SportConnect.Infrastructure.Services.Abstraction;
using System.Linq;
using System;
using SportConnect.Infrastructure.DTO;

namespace SportConnect.Infrastructure.Services.Implemenation
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public Task<bool> CheckEmailIsExist(string email)
        {
            var emailsInRepository = _userRepository
                .GetAll()
                .Select(u => u.Email);

            return Task.FromResult(emailsInRepository.Contains(email));
        }

        public Task<bool> CheckLoginIsExist(string login)
        {
            var allLoginsInRepository = _userRepository
                .GetAll()
                .Select(u => u.Login).ToList();

            return Task.FromResult(allLoginsInRepository.Contains(login));
        }

        public async Task<UserDto> Get(string email)
        {
            var user = await _userRepository.Get(email);

            return _mapper.Map<User, UserDto>(user);
        }

        public Task<LoginApiModel> TryToLoginAndGetUserRoleId(string login, string password)
        {
            var tryToLoginToAppQuery = _userRepository
                                 .GetAll()
                                 .Where(u =>
                                 (u.Login == login && u.Password == password) ||
                                 (u.Email == login && u.Password == password))
                                 .Select(u => new
                                 {
                                     UserId = u.Id,
                                     UserRoleId = (int)u.RoleId
                                 })
                                 .First();


            if (tryToLoginToAppQuery != null)
            {
                _userRepository.AddNewLogRecord(tryToLoginToAppQuery.UserId);

                var loginApiResult = new LoginApiModel
                {
                    IsSuccess = true,
                    UserRoleId = tryToLoginToAppQuery.UserRoleId
                };

                return Task.FromResult(loginApiResult);
            }
            return Task.FromResult(new LoginApiModel());

        }
    }
}