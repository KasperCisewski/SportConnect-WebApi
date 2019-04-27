using SportConnect.Core.Domain.Base;
using System;

namespace SportConnect.Core.Domain
{
    public class EventPlace : Entity<Guid>
    {
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public Address Address { get; set; }
    }
}
