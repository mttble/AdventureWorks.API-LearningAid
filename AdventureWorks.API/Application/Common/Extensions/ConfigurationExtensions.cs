﻿using AdventureWorks.API.Application.Common.Helpers;
using FluentValidation;

namespace AdventureWorks.API.Application.Common.Extensions;

public static class ConfigurationExtensions
{
    public static TSettings BindAndValidate<TSettings, TValidator>(this IConfiguration configuration)
        where TSettings : class where TValidator : AbstractValidator<TSettings>
    {
        return SettingsBinder.BindAndValidate<TSettings, TValidator>(configuration);
    }

    public static TSettings Bind<TSettings>(this IConfiguration configuration)
        where TSettings : class
    {
        return SettingsBinder.Bind<TSettings>(configuration);
    }
}