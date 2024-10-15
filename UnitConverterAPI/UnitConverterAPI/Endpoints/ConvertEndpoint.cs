using UnitConverterAPI.Models;
using UnitConverterAPI.Services;

namespace UnitConverterAPI.Endpoints;

public static class ConvertEndpoint
{
    public static void RegisterConvertUnitsEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("/convert", ConvertUnitHandler);

        static IResult ConvertUnitHandler(HttpContext context,
        ConvertRequestDto req, UnitConverterService converterService)
        {
            if (req.UnitType is null)
                return TypedResults.BadRequest(new { Error = "Must provide a 'UnitType' value." });

            if (req.From is null)
                return TypedResults.BadRequest(new { Error = "Must provide a 'From' value." });

            if (req.To is null)
                return TypedResults.BadRequest(new { Error = "Must provide a 'To' value." });

            try
            {
                decimal convertedValue = converterService.ConvertUnit(req.UnitType, req.Value, req.From, req.To);

                ConvertResponseDto response = new()
                {
                    UnitType = req.UnitType,
                    From = req.From,
                    To = req.To,
                    PreviousValue = req.Value,
                    ConvertedValue = convertedValue
                };

                return TypedResults.Ok(response);
            }
            catch (ArgumentException ex)
            {
                return TypedResults.BadRequest(new { Error = ex.Message });
            }
        }
    }
}
