using FluentValidation;

namespace AdventureWorks.API.Application.Weather.Queries.GetWeatherForecast;

public class GetWeatherForecastQueryValidator : AbstractValidator<GetWeatherForecastQuery>
{
    public GetWeatherForecastQueryValidator()
    {
        RuleFor(x => x.ErrorIfFalse).Equal(true);
    }
}