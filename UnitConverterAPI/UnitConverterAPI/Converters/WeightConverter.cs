namespace UnitConverterAPI.Converters;

public class WeightConverter
{
    public static decimal ConvertWeight(decimal value, string from, string to)
    {
        decimal valueInKg = from switch
        {
            "kg" => value,
            "g" => Math.Round(value * 0.001m, 2),
            "t" => value * 1000,
            "lb" => Math.Round(value * 0.453592m, 2),
            "oz" => Math.Round(value * 0.0283495m, 2),
            _ => throw new ArgumentException("Unknown unit of weight (From).")
        };

        return to switch
        {
            "kg" => valueInKg,
            "g" => Math.Round(valueInKg / 0.001m, 2),
            "t" => valueInKg / 1000,
            "lb" => Math.Round(valueInKg / 0.453592m, 2),
            "oz" => Math.Round(valueInKg / 0.0283495m, 2),
            _ => throw new ArgumentException("Unknown unit of weight (To).")
        };
    }
}
