using Microsoft.AspNetCore.Mvc;

namespace IoTRynningeasenWWW.Controllers
{
    [Route("api/[controller]")]
    public class PressureController : Controller
    {
        public ActionResult<string> Get()
        {
            return Ok($"{MeasurementsController.Measurements.Pressure.Current.What:F1}");
        }
    }
}