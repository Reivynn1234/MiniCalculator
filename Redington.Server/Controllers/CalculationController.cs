using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Redington.Server.Models;

namespace Redington.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculationController : ControllerBase
    {

        //private readonly ILogger<Calculation> _logger;

        //public Calculation(ILogger<Calculation> logger)
        //{
        //    _logger = logger;
        //}

        [HttpPost]
        [Route("CombinedWith")]
        public IActionResult CombinedWith([FromBody] CombinedWith data)
        {
            try
            {
                if (data.IsValid())
                {
                    return Ok(data.Calculation());
                }
                else
                {
                    return BadRequest("Inputs are out of bounds");
                }
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
            
        }

        [HttpPost]
        [Route("Either")]
        public IActionResult Either([FromBody] Either data)
        {
            try
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
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
