using UnitConverterAPI.Endpoints;
using UnitConverterAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<UnitConverterService>();

var app = builder.Build();

app.RegisterConvertUnitsEndpoints();

app.Run();
