using AddressBook.BL;
using AddressBook.BL.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Services
builder.Services.AddScoped<IBLCountry, BLCountry>();
builder.Services.AddScoped<IBLState, BLState>();
builder.Services.AddScoped<IBLCity, BLCity>();
builder.Services.AddScoped<IBLContactCategory, BLContactCategory>();
builder.Services.AddScoped<IBLContact, BLContact>();
builder.Services.AddScoped(typeof(IBLGeneric<>), typeof(BLGeneric<>));

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