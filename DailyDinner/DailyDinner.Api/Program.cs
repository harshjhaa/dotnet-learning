using DailyDinner.Api.Errors;
using DailyDinner.Api.Filters;
// using DailyDinner.Api.Middleware;
using DailyDinner.Application;
using DailyDinner.Infrastructure;
using Microsoft.AspNetCore.Mvc.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

{
    builder.Services
        .AddApplication()
        .AddInfrastructure(builder.Configuration)
        .AddControllers();
        // .AddControllers(options => options.Filters.Add<ErrorHandlingFilterAttribute>());

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    //overriding the default problem details factory
    builder.Services.AddSingleton<ProblemDetailsFactory, DailyDinnerDetailsFactory>();
}

var app = builder.Build();
{
    // app.UseMiddleware<ErrorHandlingMiddleware>();
    app.UseExceptionHandler("/error"); //handling exceptions globally
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}
