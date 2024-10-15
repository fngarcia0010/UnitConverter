using UnitConverterAPI.Contracts;

namespace UnitConverterAPI.Models;

public class Units : IUnitsOfMeasure
{
    public List<string> LengthUnits { get; } = ["cm", "m", "km", "in", "ft", "yd", "mi"];
    public List<string> WeightUnits { get; } = ["g", "kg", "lb", "oz"];
    public List<string> TemperatureUnits { get; } = ["C", "F", "K"];
}
