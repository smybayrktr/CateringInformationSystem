using System.Threading.Tasks;
using Business.Abstract;
using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepositController : ControllerBase
    {
        private IDepositService _depositService;
        private IUserService _userService;
        private UserManager<User> _userManager;

        public DepositController(IDepositService depositService,IUserService userService, UserManager<User> userManager)
        {
            _depositService = depositService;
            _userService = userService;
            _userManager = userManager;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _depositService.GetDeposits();
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(Deposit deposit)
        {
            var userId = _userManager.GetUserId(User);
            if (userId==null)
            {
                return BadRequest();
            }

            var userCheck = await _userService.GetUser(int.Parse(userId));
            if (userCheck.Data==null)
            {
                return BadRequest(userCheck);
            }
            var result = await _depositService.AddDeposit(deposit,userCheck.Data);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(Deposit deposit)
        {
            var userId = _userManager.GetUserId(User);
            if (userId==null)
            {
                return BadRequest();
            }

            var userCheck = await _userService.GetUser(int.Parse(userId));
            if (userCheck.Data==null)
            {
                return BadRequest(userCheck);
            }
            var result = await _depositService.DeleteDeposit(deposit,userCheck.Data);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPut("update")]
        public async Task<IActionResult> Update(Deposit deposit)
        {
            var result = await _depositService.UpdateDeposit(deposit);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpGet("getdeposit")]
        public async Task<IActionResult> GetDeposit(int id)
        {
            var result = await _depositService.GetDeposit(id);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpGet("getdepositsbyuserid")]
        public async Task<IActionResult> GetDepositsByUserId(int id)
        {
            var result = await _depositService.GetDepositsByUserId(id);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpGet("getdepositsbyuserschoolnumber")]
        public async Task<IActionResult> GetDepositsByUserSchoolNumber(string number)
        {
            var result = await _depositService.GetDepositsByUserSchoolNumber(number);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

    }
}
