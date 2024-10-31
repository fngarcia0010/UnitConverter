using UnitConverterAPI.Contracts;
using UnitConverterAPI.Endpoints;
using UnitConverterAPI.Services;

var builder = WebApplication.CreateBuilder(args);

var allowedOrigins = builder.Configuration.GetSection("Cors:AllowedOrigins").Get<string[]>() 
                     ?? throw new InvalidOperationException("Cors:AllowedOrigins configuration is missing.");

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", corsPolicyBuilder => corsPolicyBuilder
        .WithOrigins(allowedOrigins)
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
