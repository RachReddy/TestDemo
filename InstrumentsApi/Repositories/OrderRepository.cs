using InstrumentsApi.Models;

namespace InstrumentsApi.Repositories;

public class OrderRepository : IOrderRepository
{
    private static List<Order> _orders = new()
    {
        new Order { Id = 1, ProductName = "Laptop", Quantity = 2, Price = 999.99m, Status = "Pending" },
        new Order { Id = 2, ProductName = "Mouse", Quantity = 5, Price = 29.99m, Status = "Completed" }
    };

    public List<Order> GetAll() => _orders;

    public Order? GetById(int id) => _orders.FirstOrDefault(o => o.Id == id);

    public void Add(Order order) => _orders.Add(order);

    public void Update(Order order)
    {
        var existing = GetById(order.Id);
        if (existing == null) return;
        existing.ProductName = order.ProductName;
        existing.Quantity = order.Quantity;
        existing.Price = order.Price;
        existing.Status = order.Status;
    }

    public void Delete(int id) => _orders.RemoveAll(o => o.Id == id);

    //if you want to use remove(first find record then delete) instead of removeall(deletes dulicates)
    //var order = _orders.FirstOrDefault(o => o.Id == id);
   //_orders.Remove(order);
}