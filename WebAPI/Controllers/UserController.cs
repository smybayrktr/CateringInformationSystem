using System.Threading.Tasks;
using Business.Abstract;
using Core.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _userService.GetUsers();
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(User user)
        {
            var result = await _userService.AddUser(user);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(User user)
        {
            var result = await _userService.DeleteUser(user);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPut("update")]
        public async Task<IActionResult> Update(User user)
        {
            var result = await _userService.UpdateUser(user);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpGet("getuser")]
        public async Task<IActionResult> GetUser(int id)
        {
            var result = await _userService.GetUser(id);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpGet("getusersbyuserschoolnumber")]
        public async Task<IActionResult> GetUserByUserSchoolNumber(string number)
        {
            var result = await _userService.GetUserByUserSchoolNumber(number);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpGet("getclaims")]
        public async Task<IActionResult> GetClaims(User user)
        {
            var result = await _userService.GetClaims(user);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

    }
}
