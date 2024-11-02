using UnitConverterAPI.Converters;

namespace UnitConverterAPI.Tests;

public class TemperatureConverterConvertTemperature
{
   [Fact]
   public void ConvertTemperature25cTof()
   {
      var result = TemperatureConverter.ConvertTemperature(25, "c", "f");
      bool resultIsWrong = result != 77m;
      
      Assert.False(resultIsWrong, "25 c to f should be 77");
   }
   
   [Fact]
   public void ConvertTemperature25fToc()
   {
      var result = TemperatureConverter.ConvertTemperature(25, "f", "c");
      bool resultIsWrong = result != -3.89m;
      
      Assert.False(resultIsWrong, "25 f to c should be -3.89");
   }
   
   [Fact]
   public void ConvertTemperature25kToc()
   {
      var result = TemperatureConverter.ConvertTemperature(25, "k", "c");
      bool resultIsWrong = result != -248.15m;
      
      Assert.False(resultIsWrong, "25 k to c should be -248.15");
   }
}