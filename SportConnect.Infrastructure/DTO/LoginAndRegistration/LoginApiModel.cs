using System;

namespace SportConnect.Infrastructure.DTO.LoginAndRegistration
{
    public class LoginApiModel
    {
        public bool IsSuccess { get; set; }
        public int UserRoleId { get; set; }
        public Guid? UserId { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
    }
}
