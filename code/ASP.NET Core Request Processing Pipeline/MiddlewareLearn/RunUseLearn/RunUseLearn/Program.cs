var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
    await context.Response.WriteAsync("Request part of first middleware executed\n");
    await next();
    await context.Response.WriteAsync("Response part of first middleware executed\n");
});

app.Map("/api/Home/GetMap", customMiddleware =>
{
    customMiddleware.Use(async (context, next) =>
    {
        await context.Response.WriteAsync("Request part of map method's middleware executed\n");
        await next();
        await context.Response.WriteAsync("Response part of map method's middleware executed\n");
    });
});

app.UseWhen(context => context.Request.Path.Equals("/api/Home/GetWhen"), customMiddleware2 =>
{
    customMiddleware2.Use(async (context, next) =>
    {
        await context.Response.WriteAsync("Request part of when method's middleware executed\n");
        await next();
        await context.Response.WriteAsync("Response part of when method's middleware executed\n");
    });
});

app.Use(async (context, next) =>
{
    await context.Response.WriteAsync("Request part of second middleware executed\n");
    await next();
    await context.Response.WriteAsync("Response part of second middleware executed\n");
});

app.MapControllers();


app.Run(async (context) =>
{
    await context.Response.WriteAsync("Run method's middleware executed\n");
});

app.Use(async (context, next) =>
{
    await context.Response.WriteAsync("Request part of third middleware executed\n");
    await next();
    await context.Response.WriteAsync("Response part of third middleware executed\n");
});
app.Run();



// Run methods do end of middleware request pipeline, so after any middleware of run method doesn't executed.
// Run don't have next delegate so it's execute only one during whole middleware pipeline.

// Use method have next delegate so, it execute two time in middleware pipeline, first when request incoming and second when response outgoing.

// api/Home/Get
// Request part of first middleware executed
// Request part of second middleware executed
// Run method's middleware executed
// Response part of second middleware executed
// Response part of first middleware executed

// Map method match path and if it is match then it execute only those middleware which we are binding to it.
// api/Home/GetMap
// Request part of first middleware executed
// Request part of map method's middleware executed

// When method is check the condition and if it is true then run middleware which we are binding else it skip it and execute next middleware.
// api/Home/GetWhen
// Request part of first middleware executed
// Request part of when method's middleware executed
// Request part of second middleware executed
// Run method's middleware executed
// Response part of second middleware executed
// Response part of when method's middleware executed
// Response part of first middleware executed