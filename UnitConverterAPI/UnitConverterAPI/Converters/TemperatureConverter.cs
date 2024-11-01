namespace UnitConverterAPI.Converters;

public class TemperatureConverter
{
    public static decimal ConvertTemperature(decimal value, string from, string to)
    {
        decimal valueInCelsius = from switch
        {
            "C" => value,
            "F" => Math.Round((value - 32) * 5 / 9, 2),
            "K" => Math.Round(value - 273.15m, 2),
            _ => throw new ArgumentException("Unknown unit of temperature (From).")
        };

        return to switch
        {
            "C" => valueInCelsius,
            "F" => valueInCelsius * 9 / 5 + 32,
            "K" => Math.Round(valueInCelsius + 273.15m, 2),
            _ => throw new ArgumentException("Unknown unit of temperature (To).")
        };
    }
}
