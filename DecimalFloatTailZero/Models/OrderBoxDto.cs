using System.Collections.Generic;

namespace DecimalFloatTailZero.Models
{
    public class OrderBoxDto
    {
        public OrderDto OrderDto { get; set; }

        public IEnumerable<OrderDetailDto> OrderDetailDtos { get; set; }
    }
}