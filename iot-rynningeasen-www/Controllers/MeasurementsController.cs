using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers.Internal;
using Microsoft.AspNetCore.SignalR;

namespace iot_rynningeasen_www.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeasurementsController : ControllerBase
    {
        public static string CurrentPressure = "waiting...";
        public static string CurrentTemperature = "waiting...";

        private readonly IHubContext<MeasurementsHub> _hub;

        public MeasurementsController(IHubContext<MeasurementsHub> hub)
        {
            _hub = hub;
        }

        [HttpPost]
        public IActionResult Post([FromBody] List<SensorGroup> sensorGroups)
        {
            var pressureGroup = sensorGroups.FirstOrDefault(x => x.Name == "pressure");
            var tempGroup = sensorGroups.FirstOrDefault(x => x.Name == "temp");

            var pressureValue = pressureGroup?.Values.FirstOrDefault(x => x.Key == "sensor:102:pressure").Value;
            var tempValue = tempGroup?.Values.FirstOrDefault(x => x.Key == "sensor:101:temp").Value;

            CurrentPressure = pressureValue != null ? $"{pressureValue:F2}" : "N/A";
            CurrentTemperature = tempValue != null ? $"{tempValue:F2}" : "N/A";

            _hub.Clients.All.SendAsync("newpressure", CurrentPressure);
            _hub.Clients.All.SendAsync("newtemperature", CurrentTemperature);
            
            return Ok();
        }
    }
}