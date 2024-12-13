using FluentValidation;
using Microsoft.Data.SqlClient;

namespace AdventureWorks.API.Application.Common.Settings;

public class ConnectionStringsValidator : AbstractValidator<ConnectionStrings>
{
    public ConnectionStringsValidator()
    {
        RuleFor(x => x.AdventureWorks)
            .NotEmpty()
            .Must(BeAValidConnectionString)
            .WithMessage("Must be a valid connection string.");

    }

    private static bool BeAValidConnectionString(string connectionString)
    {
        try
        {
            new SqlConnectionStringBuilder(connectionString);
            return true;
        }
        catch
        {
            return false;
        }
    }
}