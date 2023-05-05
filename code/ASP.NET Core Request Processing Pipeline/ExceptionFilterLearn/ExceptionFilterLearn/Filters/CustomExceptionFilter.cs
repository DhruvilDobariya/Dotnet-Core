using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;
using System.Text.Json.Nodes;

namespace ExceptionFilterLearn.Filters
{
    public class CustomExceptionFilter : IAsyncExceptionFilter
    {
        public Task OnExceptionAsync(ExceptionContext context)
        {

            StackTrace stackTrace = new StackTrace(context.Exception, true);
            StackFrame frame = stackTrace.GetFrame(0);
            var jsonObjetct = new JsonObject();
            jsonObjetct.Add("Exception", context.Exception.GetType().Name);
            jsonObjetct.Add("Description", context.Exception.Message);
            jsonObjetct.Add("File Name", frame.GetFileName());
            jsonObjetct.Add("Line Number", frame.GetFileLineNumber());
            jsonObjetct.Add("Date and Time", DateTime.UtcNow.ToString("dd-mm-yyyy HH:mm:ss"));

            if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "Log")))
            {
                Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "Log"));
            }
            using (StreamWriter streamWriter = File.AppendText(Path.Combine(Directory.GetCurrentDirectory(), "Log/Log.json")))
            {
                streamWriter.WriteLine(jsonObjetct.ToString());
            }

            context.Result = new ObjectResult(new { error = context.Exception.Message })
            {
                StatusCode = 500
            };

            return Task.CompletedTask;
        }
    }
}
