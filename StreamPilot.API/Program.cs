using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using StreamPilot.Api.Configurations;
using StreamPilot.Api.Interceptors;
using StreamPilot.Data.Context;
using StreamPilot.API.Services;
using StreamPilot.Api.Utilities;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddDbContext<StreamPilotDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("StreamPilotDatabase")) 
        .AddInterceptors(new SlowQueryInterceptor()));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddScoped<IConfigurationService, ConfigurationService>();
builder.Services.Configure<FileManager>(options =>
    {
        builder.Configuration.GetSection(nameof(FileManager)).Bind(options);
    })
    .AddSingleton<IValidateOptions<FileManager>, FileManagerValidation>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
    {
        var forecast = Enumerable.Range(1, 5).Select(index =>
                new WeatherForecast
                (
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    summaries[Random.Shared.Next(summaries.Length)]
                ))
            .ToArray();
        return forecast;
    })
    .WithName("GetWeatherForecast")
    .WithOpenApi();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}