using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;

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

            var data1 = JsonSerializer.Deserialize<object>(response1);
            var data2 = JsonSerializer.Deserialize<object>(response2);

            // Combine the responses as needed
            var aggregatedData = new
            {
                Data1 = data1,
                Data2 = data2
            };

            return Ok(aggregatedData);
        }
    }

    public class DataItem
    {
        public int Id { get; set; }
        public string ContentType { get; set; }
        public string Description { get; set; }
    }
}