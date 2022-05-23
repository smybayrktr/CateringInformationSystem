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
    public class ReservationController : ControllerBase
    {
        private IReservationService _reservationService;
        private IUserService _userService;
        private UserManager<User> _userManager;

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _reservationService.GetReservations();
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(Reservation reservation)
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
            var result = await _reservationService.AddReservation(reservation,userCheck.Data);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(Reservation reservation)
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
            var result = await _reservationService.DeleteReservation(reservation,userCheck.Data);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPut("update")]
        public async Task<IActionResult> Update(Reservation reservation)
        {
            var result = await _reservationService.UpdateReservation(reservation);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpGet("getreservation")]
        public async Task<IActionResult> GetReservation(int id)
        {
            var result = await _reservationService.GetReservation(id);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpGet("getreservationsbyuserid")]
        public async Task<IActionResult> GetReservationsByUserId(int id)
        {
            var result = await _reservationService.GetReservationsByUserId(id);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpGet("getreservationsbyuserschoolnumber")]
        public async Task<IActionResult> GetReservationsByUserSchoolNumber(string number)
        {
            var result = await _reservationService.GetReservationsByUserSchoolNumber(number);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
