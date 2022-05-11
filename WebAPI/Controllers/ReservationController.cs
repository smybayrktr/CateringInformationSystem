using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _reservationService.GetReservations();
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Reservation reservation)
        {
            var result = _reservationService.AddReservation(reservation);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpDelete("delete")]
        public IActionResult Delete(Reservation reservation)
        {
            var result = _reservationService.DeleteReservation(reservation);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPut("update")]
        public IActionResult Update(Reservation reservation)
        {
            var result = _reservationService.UpdateReservation(reservation);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpGet("getreservation")]
        public IActionResult GetReservation(int id)
        {
            var result = _reservationService.GetReservation(id);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpGet("getreservationsbyuserid")]
        public IActionResult GetReservationsByUserId(int id)
        {
            var result = _reservationService.GetReservationsByUserId(id);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpGet("getreservationsbyuserschoolnumber")]
        public IActionResult GetReservationsByUserSchoolNumber(string number)
        {
            var result = _reservationService.GetReservationsByUserSchoolNumber(number);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
