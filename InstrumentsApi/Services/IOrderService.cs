using InstrumentsApi.DTOs;
using InstrumentsApi.Models;

namespace InstrumentsApi.Services;

public interface IOrderService
{
    List<Order> GetAll();
    Order? GetById(int id);
    Order Create(CreateOrderDto dto);
    bool Update(int id, CreateOrderDto dto);
    bool Delete(int id);
}