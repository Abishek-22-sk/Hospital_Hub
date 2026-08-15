namespace HealthHub.Models
{
    public class LoginResponseModel
    {
        public string? UserName { get; set; }

        public string? AccessToken { get; set; }

        public int VaildationMins { get; set; }
    }
}
