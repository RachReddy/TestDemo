using Microsoft.AspNetCore.Mvc;
using InstrumentsApi.DTOs;
using InstrumentsApi.Services;

namespace InstrumentsApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly IOrderService _service;

    public OrderController(IOrderService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetAll() => Ok(_service.GetAll());

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var order = _service.GetById(id);
        if (order == null) return NotFound($"Order {id} not found");
        return Ok(order);
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreateOrderDto dto)
    {
        var created = _service.Create(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        //var created = _service.Create(dto);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] CreateOrderDto dto)
    {
        if (!_service.Update(id, dto)) return NotFound($"Order {id} not found");
        return Ok("Order updated successfully");
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        if (!_service.Delete(id)) return NotFound($"Order {id} not found");
        return Ok("Order deleted successfully");
    }
}