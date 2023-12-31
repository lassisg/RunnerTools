﻿using RunnerTools.Application.Common.Interfaces;
using RunnerTools.Infrastructure.Persistence;
using RunnerTools.WebUI.Filters;
using RunnerTools.WebUI.Services;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using NSwag;
using NSwag.Generation.Processors.Security;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static IServiceCollection AddWebUIServices(this IServiceCollection services)
    {
        services.AddDatabaseDeveloperPageExceptionFilter();

        services.AddScoped<ICurrentUserService, CurrentUserService>();

        services.AddHttpContextAccessor();

        services.AddHealthChecks()
                .AddDbContextCheck<ApplicationDbContext>();

        services.AddControllersWithViews(options => 
                                             options.Filters.Add<ApiExceptionFilterAttribute>());
        
        services.AddFluentValidationAutoValidation();
        services.AddFluentValidationClientsideAdapters();
        
        services.AddRazorPages();

        services.ConfigureApplicationCookie(config =>
        {
            config.LoginPath = "/Account/Login";
        });

        // Customise default API behaviour
        services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);

        // services.AddOpenApiDocument(configure =>
        // {
        //     configure.Title = "RunnerTools API";
        //     configure.AddSecurity("JWT", Enumerable.Empty<string>(), new OpenApiSecurityScheme
        //     {
        //         Type = OpenApiSecuritySchemeType.ApiKey,
        //         Name = "Authorization",
        //         In = OpenApiSecurityApiKeyLocation.Header,
        //         Description = "Type into the textbox: Bearer {your JWT token}."
        //     });
        //
        //     configure.OperationProcessors.Add(new AspNetCoreOperationSecurityScopeProcessor("JWT"));
        // });

        return services;
    }
}