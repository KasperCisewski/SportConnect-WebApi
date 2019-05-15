using System;

namespace SportConnect.Infrastructure.DTO.User
{
    public class UserProfileModel
    {
        public Guid UserId { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public int FacouriteSportTypeId { get; set; }
    }
}
