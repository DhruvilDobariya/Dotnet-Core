using Infrastructure;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace FirstOption.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IEnumerable<IReminderService> _reminderServices;
        public HomeController(IEnumerable<IReminderService> reminderServices)
        {
            _reminderServices = reminderServices;
        }

        [HttpGet]
        public IActionResult EmailReminder()
        {
            var emailReminderService = _reminderServices.FirstOrDefault(x => x.GetType() == typeof(EmailReminderService));

            if (emailReminderService != null)
            {
                return Ok(emailReminderService.SendReminder());
            }

            return Ok("No service found");
        }

        [HttpGet]
        public IActionResult SmsReminder()
        {
            var smsReminderService = _reminderServices.FirstOrDefault(x => x.GetType() == typeof(SmsReminderService));

            if (smsReminderService != null)
            {
                return Ok(smsReminderService.SendReminder());
            }

            return Ok("No service found");
        }

        [HttpGet]
        public IActionResult PushNotificationReminder()
        {
            var pushNotificationReminderService = _reminderServices.FirstOrDefault(x => x.GetType() == typeof(PushNotificationReminderService));

            if (pushNotificationReminderService != null)
            {
                return Ok(pushNotificationReminderService.SendReminder());
            }

            return Ok("No service found");
        }

        // Inject multiple service and select one

        // Advantages:
        // This is consider to be an anti pattern.
        // The service provider class is not injected, so those service which we don't want that not resolved accidentally.


        // Disadvantages:
        // Code become hard to test
        // We will take lot of efforts to mock dependency
        // More runtime error then compile time error

    }
}
