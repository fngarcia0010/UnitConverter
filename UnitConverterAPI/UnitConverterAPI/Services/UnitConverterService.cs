using UnitConverterAPI.Converters;

namespace UnitConverterAPI.Services;

public class UnitConverterService
{
    public decimal ConvertUnit(string unitType, decimal value, string from, string to)
    {
        unitType = unitType.ToLower();
        
        return unitType switch
        {
            "length" => LengthConverter.ConvertLength(value, from, to),
            "weight" => WeightConverter.ConvertWeight(value, from, to),
            "temperature" => TemperatureConverter.ConvertTemperature(value, from, to),
            _ => throw new ArgumentException("Unknown or incompatible type"),
        };
    }
}
