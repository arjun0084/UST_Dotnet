using microservices.Srevices.AuthAPI.Models;

namespace microservices.Srevices.AuthAPI.Service.IService
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(ApplicationUser applicationUser);
    }
}
