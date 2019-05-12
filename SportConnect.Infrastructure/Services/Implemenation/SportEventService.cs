using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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
        private readonly IAddressRepository _addressRepository;
        private readonly IEventPlaceRepository _eventPlaceRepository;
        private readonly IEventTypeRepository _eventTypeRepository;

        public SportEventService(
            ISportEventRepository sportEventRepository,
            IUserRepository userRepository,
            IAddressRepository addressRepository,
            IEventPlaceRepository eventPlaceRepository,
            IEventTypeRepository eventTypeRepository)
        {
            _sportEventRepository = sportEventRepository;
            _userRepository = userRepository;
            _addressRepository = addressRepository;
            _eventPlaceRepository = eventPlaceRepository;
            _eventTypeRepository = eventTypeRepository;
        }

        public List<SportEventModel> GetSportEvents(SportEventApiModel sportEventApiModel)
        {
            var events = _sportEventRepository
                .GetAll()
                .OrderByDescending(se => CountDistance(sportEventApiModel.Latitude, sportEventApiModel.Longitude, se.EventPlace.Latitude, se.EventPlace.Longitude))
                .Skip(sportEventApiModel.Skip)
                .Take(sportEventApiModel.Take)
                .Include(e => e.EventPlace).ThenInclude(ep => ep.Address)
                .Include(e => e.SportType)
                .Include(e => e.ProposedEventSkillLevel)
                .ToList()
                .Select(se => new SportEventModel
                {
                    Id = se.Id,
                    EventName = se.EventName,
                    EventDate = se.EventStartDate,
                    SportTypeName = se.SportType.SportName,
                    AddressDescription = GetAddresDescription(se.EventPlace.Address),
                    QuantityOfEventParticipantsDescription = (se.ConfirmedEventParticipants.Count() + "/" + se.MaximumNumberOfParticipants).ToString(),
                    ProposedEventSkillLevel = se.ProposedEventSkillLevel.Name,
                    SportEventManagerName = _userRepository.GetById(se.SportEventManagerId).Result.Login,
                    CanJoinToEvent = true
                }).ToList();

            return events;
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
            description += " | " + address.ZipCode + " | " + address.Street + " " + address.HouseNumber;
            return description;
        }

        public async Task<string> AddNewSportEvent(SportEventApiModelToCreate sportEventApiModelToCreate)
        {
            var eventPlace = await GetOrCreateNewEventPlace(sportEventApiModelToCreate.CityName, sportEventApiModelToCreate.Street, sportEventApiModelToCreate.ZipCode, sportEventApiModelToCreate.HouseNumber);

            var eventType = sportEventApiModelToCreate.IsEventTypeSwitched ? await _eventTypeRepository.GetById(Core.Enums.EventType.Open) : await _eventTypeRepository.GetById(Core.Enums.EventType.Closed);

            try
            {
                await _sportEventRepository.Add(new SportEvent
                {
                    Id = Guid.NewGuid(),
                    EventName = sportEventApiModelToCreate.EventName,
                    EventStartDate = sportEventApiModelToCreate.EventStartDate,
                    EventStartTime = sportEventApiModelToCreate.EventStartTime,
                    EventEndDate = sportEventApiModelToCreate.EventEndDate,
                    EventEndTime = sportEventApiModelToCreate.EventEndTime,
                    SportTypeId = sportEventApiModelToCreate.SportTypeItemId,
                    EventPlace = eventPlace,
                    EventType = eventType,
                    MinimumNumberOfParticipants = sportEventApiModelToCreate.MinimumNumberOfParticipants,
                    MaximumNumberOfParticipants = sportEventApiModelToCreate.MaximumNumberOfParticipants,
                    SportSkillLevelId = (Core.Enums.SportSkillLevel)sportEventApiModelToCreate.ProposedSportSkillLevelId,
                    //TODO: add user id from mobile and set him to event manager
                    SportEventManagerId = _userRepository.GetAll().FirstOrDefault(u => u.RoleId == Core.Enums.Role.Administrator).Id
                });

                return "Event has been added";
            }
            catch (Exception)
            {

                throw;
            }

            return "Error";
        }

        private async Task<EventPlace> GetOrCreateNewEventPlace(string cityName, string street, string zipCode, int houseNumber)
        {
            var eventAddress = _addressRepository.GetAll()
                .FirstOrDefault(a => a.CityName == cityName &&
                a.HouseNumber == houseNumber &&
                a.Street == street &&
                a.ZipCode == zipCode);

            if (eventAddress != null)
            {
                var eventPlace = _eventPlaceRepository.GetAll()
                    .Include(ep => ep.Address)
                    .First(ep => ep.Address.Id == eventAddress.Id);
                if (eventPlace != null)
                {
                    return eventPlace;
                }
            }

            var address = new Address
            {
                Id = Guid.NewGuid(),
                Street = street,
                CityName = cityName,
                ZipCode = zipCode,
                HouseNumber = houseNumber
            };

            await _addressRepository.Add(address);

            //TODO: add getting lattitude and longitude for address from google maps 
            var eventPlaceModel = new EventPlace
            {
                Id = Guid.NewGuid(),
                Address = address,
                Latitude = 0,
                Longitude = 0
            };

            await _eventPlaceRepository.Add(eventPlaceModel);

            return eventPlaceModel;
        }
    }
}

