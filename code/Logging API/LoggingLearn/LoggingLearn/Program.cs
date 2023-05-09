using Microsoft.Extensions.Configuration;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Json log
//builder.Services.AddLogging(loggingBuilder =>
//{
//    loggingBuilder.AddJsonConsole(options =>
//    {
//        options.JsonWriterOptions = new JsonWriterOptions()
//        {
//            Indented = true
//        };
//    });
//});

// add NReco provider for file log
builder.Services.AddLogging(loggingBuilder => {
    loggingBuilder.AddFile("app.log", append: true);
});
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
