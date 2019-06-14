using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace iot_rynningeasen_www.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeasurementsController : ControllerBase
    {
        public static string CurrentPressure = "waiting...";
        public static string CurrentHumidity = "waiting...";
        public static string CurrentTemperature = "waiting...";

        private readonly IHubContext<MeasurementsHub> _hub;

        public MeasurementsController(IHubContext<MeasurementsHub> hub)
        {
            _hub = hub;
        }

        [HttpPost]
        [Route("temperature")]
        [TypeFilter(typeof(MeasurementLoggingAttribute), Arguments = new object[] {"temperature"})]
        public IActionResult PostTemperature([FromBody] Temperature temperature)
        {
            CurrentTemperature = $"{temperature.Value:F1}";
            _hub.Clients.All.SendAsync("newtemperature", CurrentTemperature);

            return Ok();
        }

        [HttpPost]
        [Route("pressure")]
        [TypeFilter(typeof(MeasurementLoggingAttribute), Arguments = new object[] {"pressure"})]
        public IActionResult PostPressure([FromBody] Pressure pressure)
        {
            CurrentPressure = $"{pressure.Value}";
            _hub.Clients.All.SendAsync("newpressure", CurrentPressure);

            return Ok();
        }

        [HttpPost]
        [Route("humidity")]
        [TypeFilter(typeof(MeasurementLoggingAttribute), Arguments = new object[] { "humidity" })]
        public IActionResult PostHumidity([FromBody] Humidity humidity)
        {
            CurrentHumidity = $"{humidity.Value}";
            _hub.Clients.All.SendAsync("newhumidity", CurrentHumidity);

            return Ok();
        }
    }
}