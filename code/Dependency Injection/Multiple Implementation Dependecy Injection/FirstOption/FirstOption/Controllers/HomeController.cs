using Infrastructure;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace FirstOption.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IServiceProvider _serviceProvider;
        public HomeController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        [HttpGet]
        public IActionResult EmailReminder()
        {
            var services = _serviceProvider.GetServices<IReminderService>();

            var emailReminderService = services.FirstOrDefault(x => x.GetType() == typeof(EmailReminderService));

            if (emailReminderService != null)
            {
                return Ok(emailReminderService.SendReminder());
            }
            return Ok("No service found");
        }

        [HttpGet]
        public IActionResult SmsReminder()
        {
            var services = _serviceProvider.GetServices<IReminderService>();

            var smsReminderService = services.FirstOrDefault(x => x.GetType() == typeof(SmsReminderService));

            if (smsReminderService != null)
            {
                return Ok(smsReminderService.SendReminder());
            }
            return Ok("No service found");
        }

        [HttpGet]
        public IActionResult PushNotificationReminder()
        {
            var services = _serviceProvider.GetServices<IReminderService>();

            var pushNotificationReminderService = services.FirstOrDefault(x => x.GetType() == typeof(PushNotificationReminderService));

            if (pushNotificationReminderService != null)
            {
                return Ok(pushNotificationReminderService.SendReminder());
            }
            return Ok("No service found");
        }

        // This pattern known as a service locater pattern.

        // Advantages:
        // This is consider to be an anti pattern.
        // Run time linking


        // Disadvantages:
        // Code become hard to test
        // We will take lot of efforts to mock dependency
        // More runtime error then compile time error
        // Constructor only need IServiceProvider, so it is very easy to overlook all the dependencies needed

    }
}
