using System;
using System.Linq;
using DecimalFloatTailZero.Extensions;
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

        public void Create(OrderDto vm)
        {
            vm.Guid = Guid.NewGuid();
            vm.Details
              .ForEach(d =>
                       {
                           d.Guid      = Guid.NewGuid();
                           d.OrderGuid = vm.Guid;
                       });

            _orderRepository.Create(vm);
        }

        public OrderDto GetOrder(Guid? orderGuid)
        {
            var boxDto = _orderRepository.GetOrder(orderGuid);

            boxDto.OrderDto.Details = boxDto.OrderDetailDtos.ToArray();

            return boxDto.OrderDto;
        }
    }
}
