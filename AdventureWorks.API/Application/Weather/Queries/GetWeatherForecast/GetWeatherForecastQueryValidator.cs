using FluentValidation;

namespace AdventureWorks.API.Application.Weather.Queries.GetWeatherForecast;

public class GetWeatherForeCastQueryValidator : AbstractValidator<GetWeatherForecastQuery>
{
    public GetWeatherForeCastQueryValidator()
    {
        RuleFor(x => x.City).Must(x => x.Equals("Adelaide", StringComparison.OrdinalIgnoreCase))
            .WithMessage("Only Adelaide is supported at this time.");
    }
}