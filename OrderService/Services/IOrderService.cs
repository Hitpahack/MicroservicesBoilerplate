using OrderService.DTOs;
using OrderService.Models;

namespace OrderService.Services
{
    public interface IOrderService
    {
        List<Order> GetAllOrders();
        Order GetOrderById(int id);
        Task<Order> CreateOrder(OrderDto orderDto);
        Order UpdateOrder(int id, OrderDto orderDto);
        Order DeleteOrder(int id);

       

    }
}
