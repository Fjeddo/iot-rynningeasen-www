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

        public static Measurements Measurements = new Measurements();

        private readonly IHubContext<MeasurementsHub> _hub;

        public MeasurementsController(IHubContext<MeasurementsHub> hub)
        {
            _hub = hub;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Measurements);
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
            Measurements.Temperature.AverageYesterday.Set(temperature.Value);

            Average.Yesterday = $"{temperature.Value:F1}";
            _hub.Clients.All.SendAsync("newaverage", Average);

            return Ok();
        }

        [HttpPost]
        [Route("average/temperature/w")]
        public IActionResult PostAverageW([FromBody] AverageRequest temperature)
        {
            Measurements.Temperature.AverageLastWeek.Set(temperature.Value);

            Average.LastWeek = $"{temperature.Value:F1}";
            _hub.Clients.All.SendAsync("newaverage", Average);

            return Ok();
        }

        [HttpPost]
        [Route("max/temperature/t")]
        public IActionResult PostMaxT([FromBody] MaxRequest temperature)
        {
            Measurements.Temperature.MaxToday.Set(temperature.Value);

            Max.Today = $"{temperature.Value:F1}";
            _hub.Clients.All.SendAsync("newmax", Max);

            return Ok();
        }

        [HttpPost]
        [Route("max/temperature/w")]
        public IActionResult PostMaxW([FromBody] MaxRequest temperature)
        {
            Measurements.Temperature.MaxLastWeek.Set(temperature.Value);

            Max.LastWeek = $"{temperature.Value:F1}";
            _hub.Clients.All.SendAsync("newmax", Max);

            return Ok();
        }

        [HttpPost]
        [Route("temperature")]
        [TypeFilter(typeof(MeasurementLoggingAttribute), Arguments = new object[] {"temperature"})]
        public IActionResult PostTemperature([FromBody] Temperature temperature)
        {
            Measurements.Temperature.Current.Set(temperature.Value);

            CurrentTemperature = $"{temperature.Value:F1}";
            _hub.Clients.All.SendAsync("newtemperature", CurrentTemperature);

            return Ok();
        }

        [HttpPost]
        [Route("pressure")]
        [TypeFilter(typeof(MeasurementLoggingAttribute), Arguments = new object[] {"pressure"})]
        public IActionResult PostPressure([FromBody] Pressure pressure)
        {
            Measurements.Pressure.Current.Set(pressure.Value);

            CurrentPressure = $"{pressure.Value}";
            _hub.Clients.All.SendAsync("newpressure", CurrentPressure);

            return Ok();
        }

        [HttpPost]
        [Route("humidity")]
        [TypeFilter(typeof(MeasurementLoggingAttribute), Arguments = new object[] { "humidity" })]
        public IActionResult PostHumidity([FromBody] Humidity humidity)
        {
            Measurements.Humidity.Current.Set(humidity.Value);

            CurrentHumidity = $"{humidity.Value}";
            _hub.Clients.All.SendAsync("newhumidity", CurrentHumidity);

            return Ok();
        }
    }
}