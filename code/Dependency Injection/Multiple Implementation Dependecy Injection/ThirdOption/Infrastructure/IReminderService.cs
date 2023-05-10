namespace Infrastructure
{
    public delegate IReminderService ReminderServiceResolver(string identifier);
    public interface IReminderService
    {
        string SendReminder();
    }
}