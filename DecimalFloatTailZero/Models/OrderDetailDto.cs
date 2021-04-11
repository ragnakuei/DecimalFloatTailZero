using System;
using System.Text.Json.Serialization;
using DecimalFloatTailZero.Infra;

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
        /// 項目
        /// </summary>
        public string Item { get; set; }

        /// <summary>
        /// 單價
        /// </summary>
        [JsonConverter(typeof(StringToNullableDecimalJsonConverter))]
        public decimal? UnitPrice { get; set; }

        /// <summary>
        /// 數量
        /// </summary>
        public int? Count { get; set; }

        /// <summary>
        /// 金額
        /// </summary>
        [JsonConverter(typeof(StringToNullableDecimalJsonConverter))]
        public decimal? Amount { get; set; }

        /// <summary>
        /// 備註
        /// </summary>
        public string Comment { get; set; }
    }
}
