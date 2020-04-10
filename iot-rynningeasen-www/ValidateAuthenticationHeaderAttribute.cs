using System.Linq;
using System.Net;
using System.Net.Http;
using IoTRynningeasenWWW;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;

namespace IotRynningeasenWWW
{
    public class ValidateAuthenticationHeaderAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if(context.HttpContext.Request.Method == HttpMethod.Get.Method)
            {
                return;
            }

            if (context.HttpContext.Request.Headers.TryGetValue("X-IoTRynningeasen-ApiKey", out var headerValues))
            {
                if (headerValues.SingleOrDefault() == Startup.Configuration.GetSection("Authorization").GetValue<string>("IoTRynningeasenApiKey"))
                {
                    return;
                }
            }

            context.Result = new ContentResult
            {
                Content = "Authorization failed",
                ContentType = "text/plain",
                StatusCode = (int) HttpStatusCode.Unauthorized
            };
        }
    }
}