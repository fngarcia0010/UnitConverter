using UnitConverterAPI.Contracts;

namespace UnitConverterAPI.Endpoints;

public static class UnitsEndpoint
{
    public static void RegisterUnitsEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/units", async (HttpContext context) =>
        {
            var unitsService = context.RequestServices.GetRequiredService<IUnitsOfMeasure>();

            var result = new
            {
                length = unitsService.LengthUnits,
                weight = unitsService.WeightUnits,
                temperature = unitsService.TemperatureUnits
            };

            await context.Response.WriteAsJsonAsync(result);
        });
    }
}