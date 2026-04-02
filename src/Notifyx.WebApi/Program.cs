using Notifyx.Application;
using Notifyx.Infrastructure;
using Notifyx.WebApi.BackgroundServices;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration)
    .AddOpenApi();

builder.Services.AddHostedService<RabbitMqConsumerService>();
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.Run();
