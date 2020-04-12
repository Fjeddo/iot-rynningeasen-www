using System;
using Microsoft.AspNetCore.Mvc;

namespace IoTRynningeasenWWW.Controllers
{
    [Route("api/[controller]")]
    public class HumidityController : Controller
    {
        public ActionResult<string> Get()
        {
            return Ok(FormattableString.Invariant($"{MeasurementsController.Measurements.Humidity.Current.What:F1}"));
        }
    }
}