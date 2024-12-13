using AdventureWorks.API.Application.Weather.Queries.GetWeatherForecast;
using AdventureWorks.API.Contracts.Requests;
using AdventureWorks.API.Mappers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AdventureWorks.API.Controllers;

[ApiController]
public class WeatherForecastController(ILogger<WeatherForecastController> logger, ISender mediator) : ControllerBase
{
    
    [HttpGet("/api/v1/weather")]
    public async Task<IActionResult> GetWeather([FromQuery] WeatherRequest weatherRequest)
    {
        logger.LogDebug("Received request to get weather forecast..");

        var result = await mediator.Send(new GetWeatherForecastQuery(weatherRequest.City));
        return result.IsError ? result.FirstError.ToActionResult() : Ok(result.Value);
    }
}