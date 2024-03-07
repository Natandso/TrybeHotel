using Microsoft.AspNetCore.Mvc;
using TrybeHotel.Models;
using TrybeHotel.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using TrybeHotel.Dto;

namespace TrybeHotel.Controllers
{
    [ApiController]
    [Route("booking")]
  
    public class BookingController : Controller
    {
        private readonly IBookingRepository _repository;
        public BookingController(IBookingRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Authorize(Policy = "Client")]
        public IActionResult Add([FromBody] BookingDtoInsert bookingInsert){
            var email = User.FindFirst(ClaimTypes.Email).Value;
            if (email == null){
                return StatusCode(401, new { message = ("User not found")});
            }
            try{
                var response = _repository.Add(bookingInsert, email);
                return Created("", response);

            }catch(Exception e){
                return StatusCode(400, new { message = e.Message });
            }
        }


        [HttpGet("{Bookingid}")]
       [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Authorize(Policy = "Client")]
        public IActionResult GetBooking(int Bookingid){
            var email = User.FindFirst(ClaimTypes.Email).Value;
            if (email == null){
                return StatusCode(401, new { message = ("User not found")});
            }

            try{
                var response = _repository.GetBooking(Bookingid, email);
                return Ok(response);
            }catch(Exception e){
                return StatusCode(401, new { message = e.Message });
            }
        }
    }
}