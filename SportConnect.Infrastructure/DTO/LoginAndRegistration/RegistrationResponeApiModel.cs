namespace SportConnect.Infrastructure.DTO.LoginAndRegistration
{
    public class RegistrationResponseApiModel
    {
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int FavoriteSportTypeId { get; internal set; }
    }
}
