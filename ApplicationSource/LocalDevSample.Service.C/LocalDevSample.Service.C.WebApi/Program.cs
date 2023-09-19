var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy
                .WithOrigins("*")
                .WithMethods("GET");
        });
});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseHttpLogging();
}
app.UseCors();

app.MapGet("/", () =>
{
    return Results.Ok("Service C: use route /temperature");
});

app.MapGet("/temperature", () =>
{
    return Results.Json(Random.Shared.Next(-20, 55));
})
.WithName("GetTemperature")
.WithOpenApi();

app.Run();
