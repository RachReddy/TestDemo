namespace InstrumentsApi.Models;

public class Instrument
{
    public int Id {get; set;}
    public string Name {get; set;} = string.Empty;
    public string Type {get; set;} = string.Empty;
    public int Price {get; set;}
}