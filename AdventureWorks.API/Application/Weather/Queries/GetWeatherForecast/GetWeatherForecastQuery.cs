using MediatR;
using ErrorOr;

namespace AdventureWorks.API.Application.Weather.Queries.GetWeatherForecast;

public record GetWeatherForecastQuery(bool ErrorIfFalse) : IRequest<ErrorOr<List<WeatherForecast>>>;