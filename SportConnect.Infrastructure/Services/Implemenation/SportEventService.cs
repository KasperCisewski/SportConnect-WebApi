using System;
using System.Linq;
using System.Threading.Tasks;
using SportConnect.Core.Domain;
using SportConnect.Core.Repositories;
using SportConnect.Infrastructure.DTO.SportEvent;
using SportConnect.Infrastructure.Services.Abstraction;

namespace SportConnect.Infrastructure.Services.Implemenation
{
    public class SportEventService : ISportEventService
    {
        private readonly ISportEventRepository _sportEventRepository;
        private readonly IUserRepository _userRepository;

        public SportEventService(
            ISportEventRepository sportEventRepository,
            IUserRepository userRepository)
        {
            _sportEventRepository = sportEventRepository;
            _userRepository = userRepository;
        }

        public IQueryable<SportEventModel> GetSportEvents(SportEventApiModel sportEventApiModel)
        {
            return _sportEventRepository
                .GetAll()
                .OrderByDescending(se => CountDistance(sportEventApiModel.Latitude, sportEventApiModel.Longitude, se.EventPlace.Latitude, se.EventPlace.Longitude))
                .Skip(sportEventApiModel.Skip)
                .Take(sportEventApiModel.Take)
                .Select(se => new SportEventModel
                {
                    EventName = se.EventName,
                    EventDate = se.EventStartDate,
                    SportTypeName = se.SportType.SportName,
                    AddressDescription = GetAddresDescription(se.EventPlace.Address),
                    QuantityOfEventParticipantsDescription = (se.ConfirmedEventParticipants + "/" + se.MaximumNumberOfParticipants).ToString(),
                    ProposedEventSkillLevel = se.ProposedEventSkillLevel.Name,
                    SportEventManagerName = _userRepository.GetById(se.SportEventManager).Result.Login,
                    CanJoinToEvent = true
                });
        }

        private double CountDistance(
            double userLatitude,
            double userLongitude,
            double sportEventLatitude,
            double sportEventLongitude)
        {
            if ((userLatitude == sportEventLatitude) && (userLongitude == sportEventLongitude))
            {
                return 0;
            }
            else
            {
                double theta = userLongitude - sportEventLongitude;
                double dist = Math.Sin(ConvertNumberToRadius(userLatitude)) * Math.Sin(ConvertNumberToRadius(sportEventLatitude))
                    + Math.Cos(ConvertNumberToRadius(userLatitude)) * Math.Cos(ConvertNumberToRadius(sportEventLatitude))
                    * Math.Cos(ConvertNumberToRadius(theta));
                return dist;
            }
        }
        private double ConvertNumberToRadius(double number) => (number * Math.PI) / 180.0;

        private string GetAddresDescription(Address address)
        {
            var description = address.CityName;
            description += "\n" + address.ZipCode + "|" + address.Street + " " + address.HouseNumber;
            return description;
        }
    }
}
