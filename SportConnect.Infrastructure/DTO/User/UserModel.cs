using System;

namespace SportConnect.Infrastructure.DTO.User
{
    public class UserModel
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
    }
}
