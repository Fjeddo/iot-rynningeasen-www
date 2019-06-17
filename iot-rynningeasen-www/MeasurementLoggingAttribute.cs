using System.Linq;
using System.Threading.Tasks;
using log4net;
using Microsoft.AspNetCore.Mvc.Filters;

namespace IoTRynningeasenWWW
{
    public class MeasurementLoggingAttribute : ActionFilterAttribute
    {
        private readonly ILog _log;
        private readonly string _type;

        public MeasurementLoggingAttribute(string type)
        {
            _log = LogManager.GetLogger(GetType());
            _type = type;
        }

        public override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var content = context.ActionArguments.SingleOrDefault().Value as dynamic;
            var measurement = new {measurement = new {type = _type, value = content.Value}};

            _log.Info(measurement);

            return base.OnActionExecutionAsync(context, next);
        }
    }
}