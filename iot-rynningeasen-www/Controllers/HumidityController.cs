using Microsoft.AspNetCore.Mvc;

namespace iot_rynningeasen_www.Controllers
{
    [Route("api/[controller]")]
    public class HumidityController : Controller
    {
        public ActionResult<string> Get()
        {
            return Ok(MeasurementsController.CurrentHumidity);
        }
    }
}