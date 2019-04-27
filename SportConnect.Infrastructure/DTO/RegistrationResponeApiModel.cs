using System;
using System.Collections.Generic;
using System.Text;

namespace SportConnect.Infrastructure.DTO
{
    public class RegistrationResponseApiModel
    {
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int FavoriteSportTypeId { get; internal set; }
    }
}
