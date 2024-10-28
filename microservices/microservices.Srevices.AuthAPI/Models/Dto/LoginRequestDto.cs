using System.Reflection.Metadata.Ecma335;

namespace microservices.Srevices.AuthAPI.Models.Dto
{
    public class LoginRequestDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
