﻿using ClientApi.Infrastructure.Validators;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;

namespace ClientApi.Configurations
{
    public static class FluentValidationSetup
    {
        public static void AddFluentValidationSetup(this IServiceCollection services)
        {
            services.AddMvc().AddFluentValidation(options => {
                options.RegisterValidatorsFromAssemblyContaining<BaseValidator>();
                options.ValidatorOptions.LanguageManager.Culture = CultureInfo.CreateSpecificCulture("en-us");
            });
        }
    }
}
