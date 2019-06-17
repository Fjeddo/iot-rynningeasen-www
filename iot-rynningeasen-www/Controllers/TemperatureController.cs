using Microsoft.AspNetCore.Mvc;

namespace IoTRynningeasenWWW.Controllers
{
    [Route("api/[controller]")]
    public class TemperatureController : Controller
    {
        public ActionResult<string> Get()
        {
            return Ok(MeasurementsController.CurrentTemperature);
        }
    }
}
