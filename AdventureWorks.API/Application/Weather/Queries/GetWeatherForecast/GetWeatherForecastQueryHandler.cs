using MediatR;
using ErrorOr;

namespace AdventureWorks.API.Application.Weather.Queries.GetWeatherForecast;

internal class GetWeatherForecastQueryHandler(ILogger<GetWeatherForecastQueryHandler> logger)
    : IRequestHandler<GetWeatherForecastQuery, ErrorOr<List<WeatherForecast>>>
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };


    public async Task<ErrorOr<List<WeatherForecast>>> Handle(GetWeatherForecastQuery request,
        CancellationToken cancellationToken)
    {
        await Task.Delay(Random.Shared.Next(200, 800), cancellationToken);
        return Enumerable.Range(1, 10).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToList();
    }
}