using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
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

        [HttpPost]
        [Route("CombinedWith")]
        public IActionResult CombinedWith([FromBody] CombinedWith data)
        {
            if (data.IsValid())
            {
                return Ok(data.Calculation());
            }
            else
            {
                return BadRequest("Inputs are out of bounds");
            }
            
        }

        [HttpPost]
        [Route("Either")]
        public IActionResult Either([FromBody] Either data)
        {
            if (data.IsValid())
            {
                return Ok(data.Calculation());
            }
            else
            {
                return BadRequest("Inputs are out of bounds");
            }
        }
    }
}
