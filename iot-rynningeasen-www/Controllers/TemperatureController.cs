using System;
using Microsoft.AspNetCore.Mvc;

namespace IoTRynningeasenWWW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemperatureController : ControllerBase
    {
        [Route("")]
        public ActionResult<string> Get()
        {
            return Ok(FormattableString.Invariant($"{MeasurementsController.Measurements.Temperature.Current.What:F1}"));
        }
        
        [Route("details")]
        public ActionResult<string> Details()
        {
            return Ok(FormattableString.Invariant($"{MeasurementsController.Measurements.Temperature.Current.What:F2} @ {MeasurementsController.Measurements.Temperature.Current.When}"));
        }
    }
}
