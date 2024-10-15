using UnitConverterAPI.Converters;

namespace UnitConverterAPI.Services;

public class UnitConverterService
{
    public decimal ConvertUnit(string unitType, decimal value, string from, string to)
    {
        return unitType switch
        {
            "Length" => LengthConverter.ConvertLength(value, from, to),
            "Weight" => WeightConverter.ConvertWeight(value, from, to),
            "Temperature" => TemperatureConverter.ConvertTemperature(value, from, to),
            _ => throw new ArgumentException("Unknown or incompatible type"),
        };
    }
}
