using AdventureWorks.API.Application.Common.Data;
using AdventureWorks.API.Application.Common.Extensions;
using AdventureWorks.API.Application.Common.Pipelines;
using AdventureWorks.API.Application.Common.Settings;
using AdventureWorks.API.Middleware;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// MediatR
builder.Services.AddValidatorsFromAssemblyContaining<Program>();
builder.Services
    .AddMediatR(options => { options.RegisterServicesFromAssemblyContaining(typeof(Program)); })
    .AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>))
    .AddScoped(typeof(IPipelineBehavior<,>), typeof(AuditLoggingBehaviour<,>));

// Connection Strings and Dapper
var connectionStrings = builder.Configuration.BindAndValidate<ConnectionStrings, ConnectionStringsValidator>();
builder.Services.AddSingleton(connectionStrings);
builder.Services.AddTransient<IDbConnectionFactory, SqlDbConnectionFactory>();


builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

app.UseRouting();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) app.MapOpenApi();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

foreach (var endpoint in app.Urls)
{
    Console.WriteLine($"Endpoint registered: {endpoint}");
}

app.Run();