using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupportRequestController : ControllerBase
    {
        ISupportRequestService _supportRequestService;

        public SupportRequestController(ISupportRequestService supportRequestService)
        {
            _supportRequestService = supportRequestService;
        }

        [HttpGet("getall")]
        public IActionResult GetSupportRequests()
        {
            var result = _supportRequestService.GetSupportRequests();
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpGet("getsupportrequest")]
        public IActionResult GetSupportRequest(int id)
        {
            var result = _supportRequestService.GetSupportRequest(id);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPost("add")]
        public IActionResult AddSupportRequest(SupportRequest supportRequest)
        {
            var result = _supportRequestService.AddSupportRequest(supportRequest);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPut("update")]
        public IActionResult UpdateSupportRequest(SupportRequest supportRequest)
        {
            var result = _supportRequestService.UpdateSupportRequest(supportRequest);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpDelete("delete")]
        public IActionResult DeleteSupportRequest(SupportRequest supportRequest)
        {
            var result = _supportRequestService.DeleteSupportRequest(supportRequest);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("getsupportrequestsbyuserid")]
        public IActionResult GetSupportRequestsByUserId(int id)
        {
            var result = _supportRequestService.GetSupportRequestsByUserId(id);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpGet("getsupportrequestsbyuserschoolnumber")]
        public IActionResult GetSupportRequestsByUserSchoolNumber(string number)
        {
            var result = _supportRequestService.GetSupportRequestsByUserSchoolNumber(number);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

    }
}
