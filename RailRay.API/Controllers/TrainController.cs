using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RailRay.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainController : ControllerBase

    {
        [HttpGet]
        public IActionResult GetAllTrains()
        {
            string[] trainNames = ["Ruhunu Kumari","Galu Kumari" ,"Udarata Menike","Podi menike"];
            return Ok(trainNames);

        }
    }
}
