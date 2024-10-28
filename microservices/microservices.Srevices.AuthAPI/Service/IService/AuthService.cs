using microservices.Services.AuthAPI.Data;
using microservices.Srevices.AuthAPI.Models;
using microservices.Srevices.AuthAPI.Models.Dto;
using Microsoft.AspNetCore.Identity;

namespace microservices.Srevices.AuthAPI.Service.IService
{
    public class AuthService : IAuthService
    {
        public readonly AppDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthService(AppDbContext db,IJwtTokenGenerator jwtTokenGenerator,UserManager<ApplicationUser> userManager,RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _jwtTokenGenerator = jwtTokenGenerator;
            _roleManager = roleManager;
        }

        public async Task<bool> AssignRole(string email, string roleName)
        { 
            var user = _db.ApplicationUser.FirstOrDefault(u=>u.Email.ToLower()==email.ToLower());
            if (user != null)
            {
                if(!_roleManager.RoleExistsAsync(roleName).GetAwaiter().GetResult())
                {
                    //create role if it is not in existance
                    _roleManager.CreateAsync(new IdentityRole(roleName)).GetAwaiter().GetResult();
                }
                await _userManager.AddToRoleAsync(user,roleName);
                return true;

            }
            return false;

        }

        public async Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto)
        {
            var user= _db.ApplicationUser.FirstOrDefault(u=>u.UserName.ToLower()== loginRequestDto.UserName.ToLower());
            bool isValid=await _userManager.CheckPasswordAsync(user, loginRequestDto.Password);
            //if role found ,generate token
            var token = _jwtTokenGenerator.GenerateToken(user);
            if (isValid == false || user == null)
            {
                return new LoginResponseDto() { User = null, Token = "" };
            }
            UserDto userDto = new()
            {
                Email = user.Email,
                Id=user.Id,
                Name=user.Name,
                PhoneNumber=user.PhoneNumber
            };
            LoginResponseDto loginResponseDto = new LoginResponseDto()
            {
                User = userDto,
                Token = token
            };
            return loginResponseDto;

        }

        public async Task<string> Register(RegistrationRequestDto registrationRequestDto)
        {
            ApplicationUser user = new()
            {
                UserName = registrationRequestDto.Email,
                Email = registrationRequestDto.Email,
                NormalizedEmail = registrationRequestDto.Email.ToUpper(),
                Name = registrationRequestDto.Name,
                PhoneNumber = registrationRequestDto.PhoneNumber,
            };
            try
            {
                var result = await _userManager.CreateAsync(user, registrationRequestDto.Password);
                if (result.Succeeded)
                {
                    var userToReturn = _db.ApplicationUser.First(user => user.UserName == registrationRequestDto.Email);

                    UserDto userDto = new()
                    {
                        Email = userToReturn.Email,
                        Id = userToReturn.Id,
                        Name = userToReturn.Name,
                        PhoneNumber = userToReturn.PhoneNumber
                    };
                    return "";
                }
                else
                {
                    return result.Errors.FirstOrDefault().Description;
                }

            }
            catch (Exception ex)
            {

            }
            return ("Error Encountered");
            
        }
    }
}
