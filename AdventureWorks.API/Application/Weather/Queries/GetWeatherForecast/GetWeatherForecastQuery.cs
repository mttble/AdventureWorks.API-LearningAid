using MediatR;
using ErrorOr;

namespace AdventureWorks.API.Application.Weather.Queries.GetWeatherForecast;

public record GetWeatherForecastQuery(string City) : IRequest<ErrorOr<List<WeatherForecast>>>;