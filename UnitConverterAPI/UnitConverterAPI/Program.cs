using UnitConverterAPI.Contracts;
using UnitConverterAPI.Endpoints;
using UnitConverterAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder => builder
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
});

builder.Services.AddScoped<IUnitsOfMeasure, UnitsService>();
builder.Services.AddScoped<UnitConverterService>();

var app = builder.Build();

app.UseCors("CorsPolicy");

app.RegisterUnitsEndpoints();
app.RegisterConvertUnitsEndpoints();

app.Run();
