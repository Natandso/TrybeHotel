using Microsoft.AspNetCore.Mvc;


namespace TrybeHotel.Controllers
{
    [ApiController]
    [Route("/")]
    public class StatusController : ControllerBase
    {
    [HttpGet]

    public IActionResult GetStatus()
    {
        return Ok(new { message = "online" }); 
    }
    
    }

}
