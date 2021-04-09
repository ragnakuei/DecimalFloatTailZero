using System;
using DecimalFloatTailZero.Controllers;

namespace DecimalFloatTailZero.Models
{
    public class OrderDto
    {
        /// <summary>
        /// Guid
        /// </summary>
        public Guid? Guid { get; set; }

        /// <summary>
        /// 名稱
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 小計
        /// </summary>
        public string SubTotal { get; set; }

        /// <summary>
        /// 營業稅
        /// </summary>
        public string BusinessTax { get; set; }

        /// <summary>
        /// 總計
        /// </summary>
        public string Total { get; set; }

        public OrderDetailDto[] OrderDetailDtos { get; set; }
    }
}
