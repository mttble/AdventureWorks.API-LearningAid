using AdventureWorks.API.Application.Weather.Queries.GetWeatherForecast;
using FluentValidation;

public class GetWeatherForecastQueryValidator : AbstractValidator<GetWeatherForecastQuery>
{
    public GetWeatherForecastQueryValidator()
    {
        RuleFor(x => x.City)
            .Must(city => city.Equals("Adelaide", StringComparison.OrdinalIgnoreCase))
            .WithMessage("Only Adelaide is supported at this time.");
    }
}