namespace UnitConverterAPI.Models;

public class ConvertRequestDto
{
    public string? UnitType { get; set; }
    public decimal Value { get; set; }
    public string? From { get; set; }
    public string? To { get; set; }
}
