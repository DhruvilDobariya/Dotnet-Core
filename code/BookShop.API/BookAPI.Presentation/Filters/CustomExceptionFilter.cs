using BookAPI.Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace BookAPI.Presentation.Filters
{
    public class CustomExceptionFilter : Attribute, IExceptionFilter
    {
        #region Private Properties
        private readonly ILogger<CustomExceptionFilter> _logger;
        #endregion

        #region Constructor
        public CustomExceptionFilter(ILogger<CustomExceptionFilter> logger)
        {
            _logger = logger;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Log exception in file
        /// </summary>
        /// <param name="context">context contains information about exception</param>
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

            _logger.LogError(JsonSerializer.Serialize(jsonObject));

            context.Result = new ObjectResult(new MessageModel()
            {
                Message = context.Exception.Message
            })
            {
                StatusCode = 500
            };

        }
        #endregion
    }
}
