using UnitConverterAPI.Endpoints;
using UnitConverterAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

builder.Services.AddScoped<UnitConverterService>();

var app = builder.Build();

app.UseCors("CorsPolicy");

app.RegisterConvertUnitsEndpoints();

app.Run();
