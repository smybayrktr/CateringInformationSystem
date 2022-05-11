using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        IFeedbackService _feedbackService;

        public FeedbackController(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }

        [HttpGet("getall")]
        public IActionResult GetFeedbacks()
        {
            var result = _feedbackService.GetFeedbacks();
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpGet("getfeedback")]
        public IActionResult GetFeedback(int id)
        {
            var result = _feedbackService.GetFeedback(id);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPost("add")]
        public IActionResult AddFeedback(Feedback feedback)
        {
            var result = _feedbackService.AddFeedback(feedback);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPut("update")]
        public IActionResult UpdateFeedback(Feedback feedback)
        {
            var result = _feedbackService.UpdateFeedback(feedback);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpDelete("delete")]
        public IActionResult DeleteFeedback(Feedback feedback)
        {
            var result = _feedbackService.DeleteFeedback(feedback);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("getfeedbacksbyuserid")]
        public IActionResult GetFeedbacksByUserId(int id)
        {
            var result= _feedbackService.GetFeedbacksByUserId(id);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpGet("getfeedbacksbyuserschoolnumber")]
        public IActionResult GetFeedbacksByUserSchoolNumber(string number)
        {
            var result = _feedbackService.GetFeedbacksByUserSchoolNumber(number);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

    }
}
