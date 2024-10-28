using Microsoft.AspNetCore.Identity;

namespace microservices.Srevices.AuthAPI.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string? Name { get; set; }
    }
}
