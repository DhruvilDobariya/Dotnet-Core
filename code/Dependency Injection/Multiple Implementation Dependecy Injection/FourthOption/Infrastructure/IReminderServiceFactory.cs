namespace Infrastructure
{
    public interface IReminderServiceFactory
    {
        IReminderService GetInstance(string token);
    }
}
