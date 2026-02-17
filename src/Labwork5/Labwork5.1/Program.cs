using Application;
using Infrastracture.Persistence;
using PresentationHttp;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddApplication()
    .AddInfrastructurePersistence()
    .AddPresentationHttp();

builder.Services.AddSwaggerGen();

WebApplication app = builder.Build();

app.MapControllers();

app.UseSwagger();
app.UseSwaggerUI();

app.Run();