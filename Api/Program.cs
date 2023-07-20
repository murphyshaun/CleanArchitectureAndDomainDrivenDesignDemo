using Api;
using Application;
using Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddPresentation()
        .AddApplicationService()
        .AddInfrastructureService(builder.Configuration);
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