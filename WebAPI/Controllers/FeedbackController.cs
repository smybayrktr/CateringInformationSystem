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
    public class FeedbackController : ControllerBase
    {
        private IFeedbackService _feedbackService;
        private UserManager<User> _userManager;
        private IUserService _userService;

        public FeedbackController(IFeedbackService feedbackService, UserManager<User> userManager)
        {
            _feedbackService = feedbackService;
            _userManager = userManager;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetFeedbacks()
        {
            var result = await _feedbackService.GetFeedbacks();
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpGet("getfeedback")]
        public async Task<IActionResult> GetFeedback(int id)
        {
            var result = await _feedbackService.GetFeedback(id);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPost("add")]
        public async Task<IActionResult> AddFeedback(Feedback feedback)
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
            var result = await _feedbackService.AddFeedback(feedback,userCheck.Data);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPut("update")]
        public async Task<IActionResult> UpdateFeedback(Feedback feedback)
        {
            var result = await _feedbackService.UpdateFeedback(feedback);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteFeedback(Feedback feedback)
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
            var result = await _feedbackService.DeleteFeedback(feedback,userCheck.Data);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("getfeedbacksbyuserid")]
        public async Task<IActionResult> GetFeedbacksByUserId(int id)
        {
            var result= await _feedbackService.GetFeedbacksByUserId(id);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpGet("getfeedbacksbyuserschoolnumber")]
        public async Task<IActionResult> GetFeedbacksByUserSchoolNumber(string number)
        {
            var result = await _feedbackService.GetFeedbacksByUserSchoolNumber(number);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

    }
}
