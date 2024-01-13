using Microsoft.AspNetCore.Mvc;
using Redington.Server.Models;

namespace Redington.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Calculation : ControllerBase
    {

        private readonly ILogger<Calculation> _logger;

        public Calculation(ILogger<Calculation> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("CombinedWith")]
        public IActionResult CombinedWith([FromBody] CombinedWith data)
        {
            return Ok(data.Calculation());
        }

        [HttpGet]
        [Route("Either")]
        public IActionResult Either([FromBody] Either data)
        {
            return Ok(data.Calculation());
        }
    }
}
