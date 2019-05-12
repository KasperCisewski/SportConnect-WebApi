using System;

namespace SportConnect.Infrastructure.DTO.SportEvent
{
    public class SportEventApiModelToCreate
    {
        public string EventName { get; set; }
        public DateTime EventStartDate { get; set; }
        public DateTime EventStartTime { get; set; }
        public DateTime EventEndDate { get; set; }
        public DateTime EventEndTime { get; set; }
        public int SportTypeItemId { get; set; }
        public string Street { get; set; }
        public int HouseNumber { get; set; }
        public string ZipCode { get; set; }
        public string CityName { get; set; }
        public bool IsEventTypeSwitched { get; set; }
        public int MinimumNumberOfParticipants { get; set; }
        public int MaximumNumberOfParticipants { get; set; }
        public int ProposedSportSkillLevelId { get; set; }
    }
}
