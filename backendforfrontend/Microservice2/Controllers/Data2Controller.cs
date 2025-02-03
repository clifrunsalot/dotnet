using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Microservice2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Data2Controller : ControllerBase
    {
        [HttpGet]
        public IActionResult GetData()
        {
            var data = new List<object>
            {
                new { Id = 1, Name = "Item1 from Microservice2" },
                new { Id = 2, Name = "Item2 from Microservice2" }
            };

            return Ok(data);
        }
    }
}