using UnitConverterAPI.Converters;

namespace UnitConverterAPI.Tests;

public class LengthConverterConvertLength
{
    [Fact]
    public void ConvertLength_250mmTocm_ReturnFalse()
    {
        var result = LengthConverter.ConvertLength(250, "mm", "cm");

        bool resultIsWrong = result != 25m;
        
        Assert.False(resultIsWrong, "250 mm to cm should be 25");
    }
    
    [Fact]
    public void ConvertLength_250cmTom_ReturnFalse()
    {
        var result = LengthConverter.ConvertLength(250, "cm", "m");

        bool resultIsWrong = result != 2.50m;
        
        Assert.False(resultIsWrong, "250 cm to m should be 2.50");
    }
    
    [Fact]
    public void ConvertLength_250mTokm_ReturnFalse()
    {
        var result = LengthConverter.ConvertLength(250, "m", "km");

        bool resultIsWrong = result != 0.25m;
        
        Assert.False(resultIsWrong, "250 m to km should be 0.25");
    } 
    
    [Fact]
    public void ConvertLength_250mToin_ReturnFalse()
    {
        var result = LengthConverter.ConvertLength(250, "m", "in");

        bool resultIsWrong = result != 9842.52m;
        
        Assert.False(resultIsWrong, "250 m to in should be 9842.52");
    }
    
    [Fact]
    public void ConvertLength_250ftToyd_ReturnFalse()
    {
        var result = LengthConverter.ConvertLength(250, "ft", "yd");

        bool resultIsWrong = result != 83.33m;
        
        Assert.False(resultIsWrong, "250 ft to yd should be 83.33");
    }
    
    [Fact]
    public void ConvertLength_250ydTomi_ReturnFalse()
    {
        var result = LengthConverter.ConvertLength(250, "yd", "mi");

        bool resultIsWrong = result != 0.14m;
        
        Assert.False(resultIsWrong, "250 yd to mi should be 0.14");
    }
}