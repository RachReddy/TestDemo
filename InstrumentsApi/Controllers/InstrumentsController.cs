using Microsoft.AspNetCore.Mvc;
using InstrumentsApi.Models;
using InstrumentsApi.Repository;

[ApiController]
[Route("api/[controller]")]
public class InstrumentsController : ControllerBase
{
    private readonly InstrumentRepository _instrumentRepository;
    public InstrumentsController(InstrumentRepository ir) //Note: dont miss public for constructor
    {
        _instrumentRepository=ir;
    }

    [HttpGet("getAll")]
    //[Route("api/getAll")]
    //This creates the URL /api/api/getDetails — double api. Pick one place to define the route.
    //public IActionResult Retrieve([FromBody]int id) // [FromBody] on a GET request is wrong
    public IActionResult Retrieve()
    {
        /*
        var dummydata = new []
        {
          new {Id=1, Name="flute", Type="A", price=10},
          new {Id=3, Name="drum", Type="C", price=40},
          new {Id=2, Name="bells", Type="A", price=20}
        };

        return Ok(dummydata);
        */

       return Ok( _instrumentRepository.getDetails());

    }

    [HttpPost("Add")]
    public IActionResult CreateEntry([FromBody] Instrument ins)
    {
       _instrumentRepository.createlist(ins);
       return Ok("created successfully");
    }
}