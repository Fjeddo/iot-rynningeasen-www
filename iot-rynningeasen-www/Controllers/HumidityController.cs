using Microsoft.AspNetCore.Mvc;

namespace IoTRynningeasenWWW.Controllers
{
    [Route("api/[controller]")]
    public class HumidityController : Controller
    {
        public ActionResult<string> Get()
        {
            return Ok($"{MeasurementsController.Measurements.Humidity.Current.What:F1}");
        }
    }
}