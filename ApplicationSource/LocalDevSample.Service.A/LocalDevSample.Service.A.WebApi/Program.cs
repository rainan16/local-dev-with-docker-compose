using LocalDevSample.Service.A.WebApi;

var builder = WebApplication.CreateBuilder(args);
var cServiceOptions = builder.Configuration.GetSection("CService").Get<CServiceOptions>();
builder.Services.AddTransient<ICServiceOptions>(_ => cServiceOptions!);


// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient<ICService, CService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}
app.UseHttpLogging();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/", () =>
{
    return Results.Ok("Service A: use route /weatherforecast");
});

app.MapGet("/weatherforecast", (ICService cService) =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            cService.GetTemperature().Result,
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();

    var result = new ApiResult("ServiceA", forecast);
    return Results.Json(result);
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}

internal record ApiResult(string ServiceName, IEnumerable<WeatherForecast> WeatherForecast);
