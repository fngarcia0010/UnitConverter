namespace UnitConverterAPI.Models;

public class ConvertResponseDto
{
    public string? UnitType { get; set; }
    public string? From { get; set; }
    public string? To { get; set; }
    public decimal PreviousValue { get; set; }
    public decimal ConvertedValue { get; set; }
}
