using InstrumentsApi.Models;

namespace InstrumentsApi.Repository;

public class InstrumentRepository
{
    private static List<Instrument> ilist= new()
    {
       new Instrument { Id = 1, Name = "flute", Type = "A", Price = 10 },
        new Instrument { Id = 3, Name = "drum", Type = "C", Price = 40 },
        new Instrument { Id = 2, Name = "bells", Type = "A", Price = 20 }
      
    };

    public List<Instrument> getDetails()
    {
        return ilist;
    }

    public void createlist(Instrument instrument)
    {
        ilist.Add(instrument);
    }

}