using OrderService.Models;
using OrderService.DTOs;
using OrderService.Data;

namespace OrderService.Services
{
    public class OrderService : IOrderService
    {
        private readonly OrderDbContext _dbContext;

        public OrderService(OrderDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //private readonly List<Order> _orders = new List<Order>(); // Temporary in-memory storage

        public List<Order> GetAllOrders()
        {
            return _dbContext.Orders.ToList();
        }

        public Order GetOrderById(int id)
        {
            return _dbContext.Orders.FirstOrDefault(x => x.Id == id);
        }

        public Order CreateOrder(OrderDto orderDto)
        {
            var newOrder = new Order
            {
                CustomerName = orderDto.CustomerName,
                TotalAmount = orderDto.TotalAmount,
                OrderDate = DateTime.UtcNow
            };

            _dbContext.Orders.Add(newOrder);
            _dbContext.SaveChanges();
            return newOrder;
        }
    }
}
