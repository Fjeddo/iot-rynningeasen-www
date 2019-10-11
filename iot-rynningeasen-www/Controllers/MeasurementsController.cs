using System;
using IotRynningeasenWWW.Models;
using IotRynningeasenWWW.Models.Requests;
using log4net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace IoTRynningeasenWWW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeasurementsController : ControllerBase
    {
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
            return Ok(
                new
                {
                    Yesterday = Measurements.Temperature.AverageYesterday.ToClientString(),
                    LastWeek = Measurements.Temperature.AverageLastWeek.ToClientString()
                });
        }

        [HttpPost]
        [Route("average/temperature/y")]
        public IActionResult PostAverageY([FromBody] AverageRequest temperature)
        {
            Measurements.Temperature.AverageYesterday.Set(temperature.Value);
            _hub.Clients.All.SendAsync("newaverage", Measurements.Temperature.AverageYesterday.ToClientString());

            return Ok();
        }

        [HttpPost]
        [Route("average/temperature/w")]
        public IActionResult PostAverageW([FromBody] AverageRequest temperature)
        {
            Measurements.Temperature.AverageLastWeek.Set(temperature.Value);
            _hub.Clients.All.SendAsync("newaverage", Measurements.Temperature.AverageLastWeek.ToClientString());

            return Ok();
        }

        [HttpPost]
        [Route("max/temperature/t")]
        public IActionResult PostMaxT([FromBody] MaxRequest temperature)
        {
            Measurements.Temperature.MaxToday.Set(temperature.Value);
            _hub.Clients.All.SendAsync("newmax", Measurements.Temperature.MaxToday.ToClientString());

            return Ok();
        }

        [HttpPost]
        [Route("max/temperature/w")]
        public IActionResult PostMaxW([FromBody] MaxRequest temperature)
        {
            Measurements.Temperature.MaxLastWeek.Set(temperature.Value);
            _hub.Clients.All.SendAsync("newmax", Measurements.Temperature.MaxLastWeek.ToClientString());

            return Ok();
        }

        [HttpPost]
        [Route("temperature")]
        [TypeFilter(typeof(MeasurementLoggingAttribute), Arguments = new object[] {"temperature"})]
        public IActionResult PostTemperature([FromBody] Temperature temperature)
        {
            Measurements.Temperature.Current.Set(temperature.Value);
            _hub.Clients.All.SendAsync("newtemperature", Measurements.Temperature.Current.ToClientString());

            return Ok();
        }

        [HttpPost]
        [Route("pressure")]
        [TypeFilter(typeof(MeasurementLoggingAttribute), Arguments = new object[] {"pressure"})]
        public IActionResult PostPressure([FromBody] Pressure pressure)
        {
            Measurements.Pressure.Current.Set(pressure.Value);
            _hub.Clients.All.SendAsync("newpressure", Measurements.Pressure.Current.ToClientString());

            return Ok();
        }

        [HttpPost]
        [Route("humidity")]
        [TypeFilter(typeof(MeasurementLoggingAttribute), Arguments = new object[] { "humidity" })]
        public IActionResult PostHumidity([FromBody] Humidity humidity)
        {
            Measurements.Humidity.Current.Set(humidity.Value);
            _hub.Clients.All.SendAsync("newhumidity", Measurements.Humidity.Current.ToClientString());

            return Ok();
        }

        [HttpPost]
        [Route("rawsensorsdata")]
        public IActionResult PostRawSensorsData([FromBody] object sensors)
        {
            var logger = LogManager.GetLogger(GetType().Assembly, "rawsensors");
            if (logger == null)
            {
                throw new Exception("No logger found");
            }

            var sensorsJObject = (Newtonsoft.Json.Linq.JObject) sensors;
            foreach (var sensor in sensorsJObject)
            {
                logger.Info(sensor.Value);
            }

            return Ok();
        }
    }
}