using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Redington.Server.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Redington.Server.Controllers
{
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
            if (result == -1)
            {
                return BadRequest(new { success = false });
            } else
            {
                return Ok(new { success = true, val = result });
            }
        }

        [HttpPost]
        [Route("Either")]
        public IActionResult Either([FromBody] Data data)
        {
            double result = _service.Either(data);
            if (result == -1)
            {
                return BadRequest(new { success = false});
            }
            else
            {
                return Ok(new { success = true, val = result });
            }
        }
    }
}
