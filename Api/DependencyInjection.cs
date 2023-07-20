using Api.Common.Errors;
using Api.Common.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {

            services.AddControllers();

            //use ErrorHandlingFilterAttribute
            //services.AddControllers(options => options.Filters.Add<ErrorHandlingFilterAttribute>());

            //ErrorsController
            services.AddSingleton<ProblemDetailsFactory, AppProblemDetailsFactory>();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddMappings();

            return services;
        }
    }
}
