using Microsoft.AspNetCore.Mvc.Filters;
using NLog;
using System.Diagnostics;
using System.Text.Json.Nodes;

namespace BookAPI.Presentation.Filters
{
    public class CustomExceptionFilter : Attribute, IExceptionFilter
    {
        private readonly ILogger<CustomExceptionFilter> _logger;
        public CustomExceptionFilter(ILogger<CustomExceptionFilter> logger) 
        {
            _logger = logger;
        }
        public void OnException(ExceptionContext context)
        {
            StackTrace stackTrace = new StackTrace(context.Exception, true);
            var frame = stackTrace.GetFrame(0);
            var jsonObject = new JsonObject();
            jsonObject.Add("Exception", context.Exception.GetType().Name);
            jsonObject.Add("Message", context.Exception.Message);
            jsonObject.Add("FileName", frame.GetFileName());
            jsonObject.Add("LineNumber", frame.GetFileLineNumber());
            jsonObject.Add("DateTime", DateTime.UtcNow.ToString("dd-MM-yyyy hh:mm:ss"));


        }
    }
}
