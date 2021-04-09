using System.Linq;
using DecimalFloatTailZero.Models;
using DecimalFloatTailZero.Repositories;

namespace DecimalFloatTailZero.Services
{
    public class OrderService
    {
        private readonly OrderRepository _orderRepository;

        public OrderService(OrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public OrderDto[] GetOrders()
        {
            var orders = _orderRepository.GetOrders().ToArray();

            return orders;
        }
    }
}
