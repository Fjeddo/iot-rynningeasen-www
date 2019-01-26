using Microsoft.AspNetCore.Mvc;

namespace iot_rynningeasen_www.Controllers
{
    [Route("api/[controller]")]
    public class PressureController : Controller
    {
        public ActionResult<string> Get()
        {
            return Ok(MqttService.Pressure);
        }
    }
}