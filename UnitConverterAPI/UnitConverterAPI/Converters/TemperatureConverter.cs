namespace UnitConverterAPI.Converters;

public class TemperatureConverter
{
    public static decimal ConvertTemperature(decimal value, string from, string to)
    {
        decimal valueInCelsius = from switch
        {
            "c" => value,
            "f" => Math.Round((value - 32) * 5 / 9, 2),
            "k" => Math.Round(value - 273.15m, 2),
            _ => throw new ArgumentException("Unknown unit of temperature (From).")
        };

        return to switch
        {
            "c" => valueInCelsius,
            "f" => valueInCelsius * 9 / 5 + 32,
            "k" => Math.Round(valueInCelsius + 273.15m, 2),
            _ => throw new ArgumentException("Unknown unit of temperature (To).")
        };
    }
}
