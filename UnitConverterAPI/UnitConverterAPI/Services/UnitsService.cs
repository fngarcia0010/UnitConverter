using UnitConverterAPI.Contracts;
using UnitConverterAPI.Models;

namespace UnitConverterAPI.Services;

public class UnitsService : IUnitsOfMeasure
{
    private readonly Units _units = new();

    public List<string> LengthUnits => _units.LengthUnits;
    public List<string> WeightUnits => _units.WeightUnits;
    public List<string> TemperatureUnits => _units.TemperatureUnits;
}
