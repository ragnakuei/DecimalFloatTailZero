using System;
using System.Text.Json.Serialization;
using DecimalFloatTailZero.Controllers;
using DecimalFloatTailZero.Extensions;
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
        // [JsonConverter(typeof(StringToNullableDecimalJsonConverter))]
        public string SubTotal
        {
            get => SubTotalDecimal?.ToString();
            set => SubTotalDecimal = value?.ToNullableDecimal();
        }

        public decimal? SubTotalDecimal;

        /// <summary>
        /// 營業稅
        /// </summary>
        // [JsonConverter(typeof(StringToNullableDecimalJsonConverter))]
        public string BusinessTax
        {
            get => BusinessTaxDecimal?.ToString();
            set => BusinessTaxDecimal = value?.ToNullableDecimal();
        }

        public decimal? BusinessTaxDecimal;

        /// <summary>
        /// 總計
        /// </summary>
        public string Total
        {
            get => TotalDecimal?.ToString();
            set => TotalDecimal = value?.ToNullableDecimal();
        }

        public decimal? TotalDecimal;

        // [JsonConverter(typeof(StringToNullableDecimalJsonConverter))]
        public string FloatPrecision
        {
            get => FloatPrecisionDecimal?.ToString();
            set => FloatPrecisionDecimal = value?.ToNullableDecimal();
        }

        public decimal? FloatPrecisionDecimal;

        public OrderDetailDto[] Details { get; set; }
    }
}
