using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace FirstOption.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IReminderServiceFactory _reminderServiceFactory;
        public HomeController(IReminderServiceFactory reminderServiceFactory)
        {
            _reminderServiceFactory = reminderServiceFactory;
        }

        [HttpGet]
        public IActionResult EmailReminder()
        {
            var emailReminderService = _reminderServiceFactory.GetInstance("Email");

            if (emailReminderService != null)
            {
                return Ok(emailReminderService.SendReminder());
            }
            return Ok("No service found");
        }

        [HttpGet]
        public IActionResult SmsReminder()
        {
            var smsReminderService = _reminderServiceFactory.GetInstance("Sms");

            if (smsReminderService != null)
            {
                return Ok(smsReminderService.SendReminder());
            }
            return Ok("No service found");
        }

        [HttpGet]
        public IActionResult PushNotificationReminder()
        {
            var pushNotificationReminderService = _reminderServiceFactory.GetInstance("PushNotification");

            if (pushNotificationReminderService != null)
            {
                return Ok(pushNotificationReminderService.SendReminder());
            }
            return Ok("No service found");
        }

        // Factory

        // Advantages:
        // Every dependency is known at compile time
        // Clean coding

    }
}
