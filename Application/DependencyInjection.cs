using Application.Authentication.Commands.Register;
using Application.Common.Behavior;
using Application.Services.Authentication.Commands;
using Application.Services.Authentication.Common;
using Application.Services.Authentication.Queries;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationCommandService, AuthenticationCommandService>();
            services.AddScoped<IAuthenticationQueryService, AuthenticationQueryService>();
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            //services.AddScoped<
            //    IPipelineBehavior<RegisterCommand, AuthenticationResult>, 
            //    ValidationBehavior>();
            //services.AddScoped<IValidator<RegisterCommand>, RegisterCommandValidator>();
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}