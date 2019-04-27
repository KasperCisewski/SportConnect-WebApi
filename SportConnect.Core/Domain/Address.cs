using SportConnect.Core.Domain.Base;
using System;

namespace SportConnect.Core.Domain
{
    public class Address : Entity<Guid>
    {
        public string Street { get; set; }
        public int HouseNumber { get; set; }
        public string ZipCode { get; set; }
        public string CityName { get; set; }
    }
}
