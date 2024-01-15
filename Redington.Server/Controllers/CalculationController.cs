using Microsoft.AspNetCore.Mvc;
using Redington.Server.Models;

namespace Redington.Server.Controllers
{
    //This controller deals with the API in regards to Data and doing calculations
    [ApiController]
    [Route("[controller]")]
    public class CalculationController : ControllerBase
    {

        private DataService _service;

        public CalculationController()
        {
            _service = new DataService();
        }

        [HttpPost]
        [Route("CombinedWith")]
        public IActionResult CombinedWith([FromBody] Data data)
        {
            double result = _service.CombinedWith(data);
            return response(result);
        }

        

        [HttpPost]
        [Route("Either")]
        public IActionResult Either([FromBody] Data data)
        {
            double result = _service.Either(data);
            return response(result);
        }

        //Helper method to reduce code duplication
        private IActionResult response(double result)
        {
            if (result == -1)
            {
                return BadRequest(new { success = false });
            }
            else
            {
                return Ok(new { success = true, val = result });
            }
        }
    }
}
