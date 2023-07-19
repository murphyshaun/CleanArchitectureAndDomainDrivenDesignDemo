using Api.Common.Errors;
using Api.Filters;
using Api.Middlewares;
using Application;
using Infrastructure;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddApplicationService()
        .AddInfrastructureService(builder.Configuration);


    builder.Services.AddControllers();

    //use ErrorHandlingFilterAttribute
    //builder.Services.AddControllers(options => options.Filters.Add<ErrorHandlingFilterAttribute>());

    //ErrorsController
    builder.Services.AddSingleton<ProblemDetailsFactory, AppProblemDetailsFactory>();

    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
}



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//customize middle: handle error (có thể dùng ErrorHandlingFilterAttribute: builder.Services.AddControllers(options => options.Filters.Add<ErrorHandlingFilterAttribute>());)
//hoặc dùng app.UseExceptionHandler("/error")
//app.UseMiddleware<ErrorHandlingMiddleware>();

//ErrorsController
app.UseExceptionHandler("/error");
//app.Map("/error", (HttpContext httpContext) =>
//{
//    var exception = httpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
//    return Results.Problem();
//});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
