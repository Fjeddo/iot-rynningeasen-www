using Microsoft.AspNetCore.Mvc;

namespace IoTRynningeasenWWW.Controllers
{
    [Route("api/[controller]")]
    public class TemperatureController : Controller
    {
        [Route("")]
        public ActionResult<string> Get()
        {
            return Ok($"{MeasurementsController.Measurements.Temperature.Current.What:F1}");
        }
        
        [Route("details")]
        public ActionResult<string> Details()
        {
            return Ok($"{MeasurementsController.Measurements.Temperature.Current.What:F1} @ {MeasurementsController.Measurements.Temperature.Current.When}");
        }
    }
}
