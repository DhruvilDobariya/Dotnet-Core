using Infrastructure;
using Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IReminderService, EmailReminderService>();
builder.Services.AddScoped<IReminderService, SmsReminderService>();
builder.Services.AddScoped<IReminderService, PushNotificationReminderService>();


builder.Services.AddTransient<ReminderServiceResolver> (serviceProvider => token =>
{
    return token switch
    {
        "Email" => serviceProvider.GetServices<IReminderService>().FirstOrDefault(x => x.GetType() == typeof(EmailReminderService)),
        "Sms" => serviceProvider.GetServices<IReminderService>().FirstOrDefault(x => x.GetType() == typeof(SmsReminderService)),
        "PushNotification" => serviceProvider.GetServices<IReminderService>().FirstOrDefault(x => x.GetType() == typeof(PushNotificationReminderService)),
        _ => throw new InvalidOperationException()
    };
});

//builder.Services.AddTransient<ReminderServiceResolver>(serviceProvider =>
//{
//    var emailService = serviceProvider.GetService<EmailReminderService>();
//    var smsService = serviceProvider.GetService<SmsReminderService>();
//    var pushNotificationService = serviceProvider.GetService<PushNotificationReminderService>();

//    return token =>
//    {
//        switch (token)
//        {
//            case "Email":
//                return emailService;
//            case "SMS":
//                return smsService;
//            case "PushNotifications":
//                return pushNotificationService;
//            default:
//                throw new InvalidOperationException();
//        }
//    };
//});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
