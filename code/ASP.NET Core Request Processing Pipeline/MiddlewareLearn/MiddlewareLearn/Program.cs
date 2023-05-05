using MiddlewareLearn.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// If we are use IMiddleware interface then we need to register dependency,
// but if we use Request delegate then we must not register dependency.
builder.Services.AddScoped<CustomMiddleware>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.Use(async (context, next) =>
{
    ILogger<Program> _logger = builder.Services.BuildServiceProvider().GetRequiredService<ILogger<Program>>();
    _logger.LogInformation("Inline middleware execute before action method");
    await next();
    _logger.LogInformation("Inline middleware execute after action method");
});

app.MapControllers();

app.UseMiddleware<CustomMiddleware>();

app.Run(); // this middleware run the application.
