using System.Threading.Tasks;
using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Security.Hashing;
using Entities.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthService _authService;
        private UserManager<User> _userManager;

        public AuthController(IAuthService authService, UserManager<User> userManager)
        {
            _authService = authService;
            _userManager = userManager;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            var userExists = await _userManager.FindByEmailAsync(userForRegisterDto.Email);
            if (userExists!=null) return BadRequest();

            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(userForRegisterDto.Password, out passwordHash, out passwordSalt);
            
            var user = new User
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                UserName = userForRegisterDto.Email,
                SchoolNumber = userForRegisterDto.UserSchoolNumber,
                HashPassword = passwordHash,
                PasswordSalt = passwordSalt
            };

            var result = await _authService.CreateAccessToken(user);
            if (!result.Success) return BadRequest(result);
          
            var createUser = await _userManager.CreateAsync(user,userForRegisterDto.Password);
            if (!createUser.Succeeded)
            {
                return BadRequest();
            }
      
            return Ok(result);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
            var result = await _authService.Login(userForLoginDto);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpGet("userexists")]
        public async Task<IActionResult> UserExists(string email)
        {
            var result = await _authService.UserExists(email);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpGet("createaccesstoken")]
        public async Task<IActionResult> CreateAccessToken(User user)
        {
            var result = await _authService.CreateAccessToken(user);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

    }
}
