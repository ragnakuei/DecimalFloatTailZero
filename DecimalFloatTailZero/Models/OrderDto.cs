using System;
using System.Text.Json.Serialization;
using DecimalFloatTailZero.Controllers;
using DecimalFloatTailZero.Infra;

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
        [JsonConverter(typeof(StringToNullableDecimalJsonConverter))]
        public decimal? SubTotal { get; set; }

        /// <summary>
        /// 營業稅
        /// </summary>
        [JsonConverter(typeof(StringToNullableDecimalJsonConverter))]
        public decimal? BusinessTax { get; set; }

        /// <summary>
        /// 總計
        /// </summary>
        [JsonConverter(typeof(StringToNullableDecimalJsonConverter))]
        public decimal? Total { get; set; }

        [JsonConverter(typeof(StringToNullableDecimalJsonConverter))]
        public decimal? FloatPrecision { get; set; }

        public OrderDetailDto[] Details { get; set; }
    }
}
