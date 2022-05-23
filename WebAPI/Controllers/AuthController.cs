using System.Threading.Tasks;
using Business.Abstract;
using Core.Entities.Concrete;
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
            // var userExist = _authService.UserExists(userForRegisterDto.Email);
            // if (!userExist.Success)
            // {
            //     return BadRequest(userExist);
            // }
            var result= _authService.Register(userForRegisterDto, password);
            if (!result.Success)
            {
                return BadRequest(result);
            }

            var user = new User
            {
                Email = result.Data.Email,
                FirstName = result.Data.FirstName,
                LastName = result.Data.LastName,
                HashPassword = result.Data.HashPassword,
                PasswordSalt = result.Data.PasswordSalt,
                SchoolNumber = result.Data.SchoolNumber,
                Status = true,
                UserName = result.Data.Email,
                Balance = result.Data.Balance
            };
            var userAdd = await _userManager.CreateAsync(user,userForRegisterDto.Password);
            if (!userAdd.Succeeded)
            {
                return BadRequest(userAdd);
            }
            return Ok(result);
        }
        [HttpPost("login")]
        public IActionResult Login(UserForLoginDto userForLoginDto)
        {
            var result = _authService.Login(userForLoginDto);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpGet("userexists")]
        public IActionResult UserExists(string email)
        {
            var result = _authService.UserExists(email);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpGet("createaccesstoken")]
        public IActionResult CreateAccessToken(User user)
        {
            var result = _authService.CreateAccessToken(user);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

    }
}
