namespace UnitConverterAPI.Converters;

public class LengthConverter
{
    public static decimal ConvertLength(decimal value, string from, string to)
    {
        decimal valueInMeters = from switch
        {
            "m" => value,
            "km" => value * 1000,
            "cm" => Math.Round(value * 0.01m, 2),
            "mm" => Math.Round(value * 0.001m, 2),
            "in" => Math.Round(value * 0.0254m, 2),
            "ft" => Math.Round(value * 0.3048m, 2),
            "yd" => Math.Round(value * 0.9144m, 2),
            "mi" => Math.Round(value * 1609.34m, 2),
            _ => throw new ArgumentException("Unknown unit of length (From).")
        };

        return to switch
        {
            "m" => valueInMeters,
            "km" => valueInMeters / 1000,
            "cm" => Math.Round(valueInMeters / 0.01m, 2),
            "mm" => Math.Round(valueInMeters / 0.001m, 2),
            "in" => Math.Round(valueInMeters / 0.0254m, 2),
            "ft" => Math.Round(valueInMeters / 0.3048m, 2),
            "yd" => Math.Round(valueInMeters / 0.9144m, 2),
            "mi" => Math.Round(valueInMeters / 1609.34m, 2),
            _ => throw new ArgumentException("Unknown unit of length (To).")
        };
    }
}
