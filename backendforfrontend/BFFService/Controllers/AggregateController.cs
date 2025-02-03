using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

namespace BFFService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AggregateController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AggregateController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> GetAggregatedData()
        {
            var client = _httpClientFactory.CreateClient();

            var response1 = await client.GetStringAsync("http://localhost:5001/api/data1");
            var response2 = await client.GetStringAsync("http://localhost:5002/api/data2");

            // Combine the responses as needed
            var aggregatedData = new
            {
                Data1 = response1,
                Data2 = response2
            };

            return Ok(aggregatedData);
        }
    }
}