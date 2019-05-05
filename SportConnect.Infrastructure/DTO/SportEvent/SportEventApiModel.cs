using System;

namespace SportConnect.Infrastructure.DTO.SportEvent
{
    public class SportEventApiModel
    {
        public Guid UserId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int Take { get; set; }
        public int Skip { get; set; }
    }
}
