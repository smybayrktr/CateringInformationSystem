using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepositController : ControllerBase
    {
        IDepositService _depositService;

        public DepositController(IDepositService depositService)
        {
            _depositService = depositService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _depositService.GetDeposits();
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Deposit deposit)
        {
            var result = _depositService.AddDeposit(deposit);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpDelete("delete")]
        public IActionResult Delete(Deposit deposit)
        {
            var result = _depositService.DeleteDeposit(deposit);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPut("update")]
        public IActionResult Update(Deposit deposit)
        {
            var result = _depositService.UpdateDeposit(deposit);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpGet("getdeposit")]
        public IActionResult GetDeposit(int id)
        {
            var result = _depositService.GetDeposit(id);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpGet("getdepositsbyuserid")]
        public IActionResult GetDepositsByUserId(int id)
        {
            var result = _depositService.GetDepositsByUserId(id);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpGet("getdepositsbyuserschoolnumber")]
        public IActionResult GetDepositsByUserSchoolNumber(string number)
        {
            var result = _depositService.GetDepositsByUserSchoolNumber(number);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

    }
}
