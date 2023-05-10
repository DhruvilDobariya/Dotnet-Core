using Infrastructure;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace FirstOption.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ReminderServiceResolver _resolver;
        public HomeController(ReminderServiceResolver resolver)
        {
            _resolver = resolver;
        }

        [HttpGet]
        public IActionResult EmailReminder()
        {
            var emailReminderService = _resolver("Email");
            
            if(emailReminderService != null)
            {
                return Ok(emailReminderService.SendReminder());
            }
            return Ok("No service found");
        }

        [HttpGet]
        public IActionResult SmsReminder()
        {
            var smsReminderService = _resolver("Sms");

            if (smsReminderService != null)
            {
                return Ok(smsReminderService.SendReminder());
            }
            return Ok("No service found");
        }

        [HttpGet]
        public IActionResult PushNotificationReminder()
        {
            var pushNotificationReminderService = _resolver("PushNotification");

            if (pushNotificationReminderService != null)
            {
                return Ok(pushNotificationReminderService.SendReminder());
            }
            return Ok("No service found");
        }

        // Service delegate

        // Advantages:
        // Type resolution is part of delegate not actual class
        // Easy testing, just we need to setup delegate which will return mock or stubs

    }
}
