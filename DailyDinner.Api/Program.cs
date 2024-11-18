using DailyDinner.Application;
using DailyDinner.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

{
    builder.Services
        .AddApplication()
        .AddInfrastructure(builder.Configuration)
        .AddControllers();

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
}

var app = builder.Build();
{
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}
