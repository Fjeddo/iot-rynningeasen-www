using IotRynningeasenWWW.Models;
using IotRynningeasenWWW.Models.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace IoTRynningeasenWWW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeasurementsController : ControllerBase
    {
        public static string CurrentPressure = "waiting...";
        public static string CurrentHumidity = "waiting...";
        public static string CurrentTemperature = "waiting...";
        public static Average Average = new Average();
        public static Max Max = new Max();

        private readonly IHubContext<MeasurementsHub> _hub;

        public MeasurementsController(IHubContext<MeasurementsHub> hub)
        {
            _hub = hub;
        }
        
        [HttpGet]
        [Route("average")]
        public IActionResult GetAverage()
        {
            return Ok(Average);
        }

        [HttpPost]
        [Route("average/temperature/y")]
        public IActionResult PostAverageY([FromBody] AverageRequest temperature)
        {
            Average.Yesterday = $"{temperature.Value:F1}";
            _hub.Clients.All.SendAsync("newaverage", Average);

            return Ok();
        }

        [HttpPost]
        [Route("average/temperature/w")]
        public IActionResult PostAverageW([FromBody] AverageRequest temperature)
        {
            Average.LastWeek = $"{temperature.Value:F1}";
            _hub.Clients.All.SendAsync("newaverage", Average);

            return Ok();
        }

        [HttpPost]
        [Route("max/temperature/t")]
        public IActionResult PostMaxT([FromBody] MaxRequest temperature)
        {
            Max.Today = $"{temperature.Value:F1}";
            _hub.Clients.All.SendAsync("newmax", Max);

            return Ok();
        }

        [HttpPost]
        [Route("max/temperature/w")]
        public IActionResult PostMaxW([FromBody] MaxRequest temperature)
        {
            Max.LastWeek = $"{temperature.Value:F1}";
            _hub.Clients.All.SendAsync("newmax", Max);

            return Ok();
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