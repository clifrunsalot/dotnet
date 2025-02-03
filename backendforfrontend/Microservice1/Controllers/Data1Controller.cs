using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Microservice1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Data1Controller : ControllerBase
    {
        [HttpGet]
        public IActionResult GetData()
        {
            var data = new List<object>
            {
                new { Id = 1, Name = "Item1 from Microservice1" },
                new { Id = 2, Name = "Item2 from Microservice1" }
            };

            return Ok(data);
        }
    }
}