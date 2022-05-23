using System.Threading.Tasks;
using Business.Abstract;
using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupportRequestController : ControllerBase
    {
        ISupportRequestService _supportRequestService;
        private IUserService _userService;
        private UserManager<User> _userManager;

        public SupportRequestController(ISupportRequestService supportRequestService, IUserService userService, UserManager<User> userManager)
        {
            _supportRequestService = supportRequestService;
            _userService = userService;
            _userManager = userManager;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetSupportRequests()
        {
            var result = await _supportRequestService.GetSupportRequests();
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpGet("getsupportrequest")]
        public async Task<IActionResult> GetSupportRequest(int id)
        {
            var result = await _supportRequestService.GetSupportRequest(id);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPost("add")]
        public async Task<IActionResult> AddSupportRequest(SupportRequest supportRequest)
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
            var result = await _supportRequestService.AddSupportRequest(supportRequest,userCheck.Data);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPut("update")]
        public async Task<IActionResult> UpdateSupportRequest(SupportRequest supportRequest)
        {
            var result = await _supportRequestService.UpdateSupportRequest(supportRequest);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteSupportRequest(SupportRequest supportRequest)
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
            var result = await _supportRequestService.DeleteSupportRequest(supportRequest,userCheck.Data);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("getsupportrequestsbyuserid")]
        public async Task<IActionResult> GetSupportRequestsByUserId(int id)
        {
            var result = await _supportRequestService.GetSupportRequestsByUserId(id);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpGet("getsupportrequestsbyuserschoolnumber")]
        public async Task<IActionResult> GetSupportRequestsByUserSchoolNumber(string number)
        {
            var result = await _supportRequestService.GetSupportRequestsByUserSchoolNumber(number);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

    }
}
