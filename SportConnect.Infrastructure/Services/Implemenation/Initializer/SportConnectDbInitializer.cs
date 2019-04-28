using SportConnect.Infrastructure.Data;
using SportConnect.Infrastructure.Services.Abstraction.Initializer;
using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace SportConnect.Infrastructure.Services.Implemenation.Initializer
{
    public class SportConnectDbInitializer : ISportConnectDbInitializer
    {
        private readonly SportConnectContext _sportConnectContext;

        public SportConnectDbInitializer(SportConnectContext sportConnectContext)
        {
            _sportConnectContext = sportConnectContext;
        }

        public async Task<bool> Initialize()
        {
            try
            {
                _sportConnectContext.Database.OpenConnection();

                if (!_sportConnectContext.Role.Any())
                {
                    await _sportConnectContext.Role.AddAsync(new Core.Domain.Role
                    {
                        Id = Core.Enums.Role.Administrator,
                        RoleName = "Administrator"
                    });
                    await _sportConnectContext.Role.AddAsync(new Core.Domain.Role
                    {
                        Id = Core.Enums.Role.Normal,
                        RoleName = "Normal"
                    });
                    await _sportConnectContext.SaveChangesAsync();
                }

                if (!_sportConnectContext.SportSkillLevel.Any())
                {
                    _sportConnectContext.SportSkillLevel.Add(new Core.Domain.SportSkillLevel
                    {
                        Id = Core.Enums.SportSkillLevel.None,
                        Name = "None"
                    });
                    _sportConnectContext.SportSkillLevel.Add(new Core.Domain.SportSkillLevel
                    {
                        Id = Core.Enums.SportSkillLevel.Amatour,
                        Name = "Amatour"
                    });
                    _sportConnectContext.SportSkillLevel.Add(new Core.Domain.SportSkillLevel
                    {
                        Id = Core.Enums.SportSkillLevel.HalfProffesional,
                        Name = "Half Proffesional"
                    });
                    _sportConnectContext.SportSkillLevel.Add(new Core.Domain.SportSkillLevel
                    {
                        Id = Core.Enums.SportSkillLevel.Professional,
                        Name = "Proffesional"
                    });
                    _sportConnectContext.SaveChanges();
                }

                if (!_sportConnectContext.EventType.Any())
                {
                    foreach (var type in Enum.GetValues(typeof(Core.Enums.EventType)))
                    {
                        await _sportConnectContext.AddAsync(new Core.Domain.EventType
                        {
                            Id = (Core.Enums.EventType)type,
                            Name = type.ToString()
                        });
                    }
                    await _sportConnectContext.SaveChangesAsync();
                }

                if (!_sportConnectContext.SportType.Any())
                {
                    _sportConnectContext.SportType.Add(new Core.Domain.SportType
                    {
                        SportName = "Football",
                        ProposedNumberOfParticipants = 12
                    });
                    _sportConnectContext.SaveChanges();

                    _sportConnectContext.SportType.Add(new Core.Domain.SportType
                    {
                        SportName = "American Football"
                    });
                    _sportConnectContext.SaveChanges();

                    _sportConnectContext.SportType.Add(new Core.Domain.SportType
                    {
                        SportName = "Voleyball",
                        ProposedNumberOfParticipants = 12
                    });
                    _sportConnectContext.SaveChanges();

                    _sportConnectContext.SportType.Add(new Core.Domain.SportType
                    {
                        SportName = "Tennis",
                        ProposedNumberOfParticipants = 2
                    });
                    _sportConnectContext.SaveChanges();

                    _sportConnectContext.SportType.Add(new Core.Domain.SportType
                    {
                        SportName = "Basketball"
                    });
                    _sportConnectContext.SaveChanges();

                    _sportConnectContext.SportType.Add(new Core.Domain.SportType
                    {
                        SportName = "Baseball"
                    });
                    _sportConnectContext.SaveChanges();

                    _sportConnectContext.SportType.Add(new Core.Domain.SportType
                    {
                        SportName = "Gym"
                    });
                    _sportConnectContext.SaveChanges();
                }

                if (!_sportConnectContext.User.Any())
                {
                    _sportConnectContext.User.Add(new Core.Domain.User
                    {
                        Login = "admin",
                        Email = "admin@sc.com",
                        Password = "test12!",
                        RoleId = Core.Enums.Role.Administrator,
                        FavouriteSportTypeId = 1
                    });
                    _sportConnectContext.SaveChanges();

                    _sportConnectContext.User.Add(new Core.Domain.User
                    {
                        Login = "user",
                        Email = "user@sc.com",
                        Password = "test12!",
                        RoleId = Core.Enums.Role.Normal,
                        FavouriteSportTypeId = 2
                    });
                    _sportConnectContext.SaveChanges();
                }

                return true;
            }
            catch (Exception e)
            {
                return false;
                throw;
            }
            finally
            {
                _sportConnectContext.Database.CloseConnection();
            }
        }
    }
}
