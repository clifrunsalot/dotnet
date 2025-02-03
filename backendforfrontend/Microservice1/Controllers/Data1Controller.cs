using Microsoft.AspNetCore.Mvc;
using Microservice1.Data;
using Microservice1.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservice1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Data1Controller : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public Data1Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetData()
        {
            var data = await Task.Run(() => _context.DataItems.ToList());
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> PostData([FromBody] DataItem dataItem)
        {
            _context.DataItems.Add(dataItem);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetData), new { id = dataItem.Id }, dataItem);
        }
    }
}