using InstrumentsApi.DTOs;
using InstrumentsApi.Models;
using InstrumentsApi.Repositories;

namespace InstrumentsApi.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _repo;

    public OrderService(IOrderRepository repo)
    {
        _repo = repo;
    }

    public List<Order> GetAll() => _repo.GetAll();

    public Order? GetById(int id) => _repo.GetById(id);

    public Order Create(CreateOrderDto dto)
    {
        var order = new Order
        {
            Id = _repo.GetAll().Count + 1,  // simple ID generation
            ProductName = dto.ProductName,
            Quantity = dto.Quantity,
            Price = dto.Price,
            Status = "Pending"
        };
        _repo.Add(order);
        return order;
    }

    public bool Update(int id, CreateOrderDto dto)
    {
        var existing = _repo.GetById(id);
        if (existing == null) return false;

        existing.ProductName = dto.ProductName;
        existing.Quantity = dto.Quantity;
        existing.Price = dto.Price;
        _repo.Update(existing);
        return true;
    }

    public bool Delete(int id)
    {
        var existing = _repo.GetById(id);
        if (existing == null) return false;
        _repo.Delete(id);
        return true;
    }
}