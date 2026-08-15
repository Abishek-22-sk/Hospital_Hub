using HealthHub.Models;

namespace HealthHub.Service
{
    public class JwtService
    {
        private readonly ApplicationDbContext applicationDbContext;
        private readonly IConfiguration configuration1;

        public JwtService(ApplicationDbContext dbContext , IConfiguration configuration)
        {
            this.applicationDbContext = dbContext;
            this.configuration1 = configuration;
        }

        //public Task<LoginResponseModel>Authentication(LoginRequestModel model)
        //{
        //    if(string.IsNullOrEmpty(model.UserName) || string.IsNullOrEmpty(model.Password))
        //        return null;

        //}
    }
}
