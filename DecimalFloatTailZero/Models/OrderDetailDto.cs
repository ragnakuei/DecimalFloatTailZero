using System;

namespace DecimalFloatTailZero.Models
{
    public class OrderDetailDto
    {
        /// <summary>
        /// Guid
        /// </summary>
        public Guid? Guid { get; set; }

        /// <summary>
        /// 訂單 Guid
        /// </summary>
        public Guid? OrderGuid { get; set; }

        /// <summary>
        /// 單價
        /// </summary>
        public string UnitPrice { get; set; }

        /// <summary>
        /// 數量
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// 備註
        /// </summary>
        public string Comment { get; set; }
    }
}