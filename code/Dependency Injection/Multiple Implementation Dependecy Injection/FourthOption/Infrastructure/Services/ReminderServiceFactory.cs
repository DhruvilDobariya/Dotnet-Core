namespace Infrastructure.Services
{
    public class ReminderServiceFactory : IReminderServiceFactory
    {
        private readonly IEnumerable<IReminderService> _reminderServices;
        public ReminderServiceFactory(IEnumerable<IReminderService> reminderServices)
        {
            _reminderServices = reminderServices;
        }

        public IReminderService GetInstance(string token)
        {
            return token switch
            {
                "Email" => GetService(typeof(EmailReminderService)),
                "Sms" => GetService(typeof(SmsReminderService)),
                "PushNotification" => GetService(typeof(PushNotificationReminderService)),
                _ => throw new InvalidOperationException()
            }; ;
        }

        public IReminderService GetService(Type type)
        {
            return _reminderServices.FirstOrDefault(x => x.GetType() == type);
        }
    }
}
