using UnitConverterAPI.Converters;

namespace UnitConverterAPI.Tests;

public class WeightConverterConvertWeight
{
    [Theory]
    [InlineData("g", "kg")]
    [InlineData("kg", "t")]
    public void ConvertWeight_250_ReturnFalse(string from, string to)
    {
        var result = WeightConverter.ConvertWeight(250, from, to );
        
        bool resultIsWrong = result != 0.25m;
        
        Assert.False(resultIsWrong, $"250 {from} to {to} should be 0.25");
    }

    [Fact]
    public void ConvertWeight_250lbTooz_ReturnFalse()
    {
        var result = WeightConverter.ConvertWeight(250, "lb", "oz");
        
        bool resultIsWrong = result != 4000.07m;
        
        Assert.False(resultIsWrong, "250 lb to oz should be 4000.07");
    }
}