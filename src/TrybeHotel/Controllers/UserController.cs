using Microsoft.AspNetCore.Mvc;
using TrybeHotel.Models;
using TrybeHotel.Repository;
using TrybeHotel.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace TrybeHotel.Controllers
{
    [ApiController]
    [Route("user")]

    public class UserController : Controller
    {
        private readonly IUserRepository _repository;
        public UserController(IUserRepository repository)
        {
            _repository = repository;
        }
        

        [HttpGet]
        [Authorize(Policy = "Admin")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult GetUsers(){
            var users = _repository.GetUsers();

            if(users == null)
            {
                return Unauthorized();
            }

            return Ok(users);
        }

        [HttpPost]
        public IActionResult Add([FromBody] UserDtoInsert user)
        {
           try
           {
               var newUser = _repository.Add(user);
               return Created("", newUser);
           }
           catch (Exception e)
           {
               return Conflict(new { message = e.Message});
           }
        }
    }
}