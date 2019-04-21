using System;
using System.Collections.Generic;
using System.Text;

namespace SportConnect.Core.Domain
{
    public class User
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        protected User()
        {
        }

        public User(Guid userId, string login, string email, string password)
        {
            Id = userId;
            Login = login;
            Email = email;
            Password = password;
        }
    }
}
