namespace UnitConverterAPI.Contracts;

public interface IUnitsOfMeasure
{
    List<string> LengthUnits { get; }
    List<string> WeightUnits { get; }
    List<string> TemperatureUnits { get; }
}
