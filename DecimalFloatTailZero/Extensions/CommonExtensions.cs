using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace DecimalFloatTailZero.Extensions
{
    public static class CommonExtensions
    {
        public static string ToJson(this object obj)
        {
            return JsonSerializer.Serialize(obj);
        }

        public static void ForEach<TElement>(this IEnumerable<TElement> elements, Action<TElement> action)
        {
            foreach (var element in elements)
            {
                action.Invoke(element);
            }
        }

        /// <summary>
        /// 四捨五入 + 補齊浮點數 0
        /// </summary>
        public static decimal ToFixAndFillTailZero(this decimal input, int digits)
        {
            var fixValue = input.ToFix(digits);

            var fixValueStr = fixValue.ToString();

            var fillDigits = fixValueStr.Contains(".")
                                 ? digits - fixValueStr.Split(".")[1].Length
                                 : digits;

            // 0 * 1.00m 還是 0，不符合預期
            // 額外處理
            if (fixValue == 0m)
            {
                var zeroResultStrings = new List<string>
                                        {
                                            "0",
                                            "."
                                        };
                var floatZeros = Enumerable.Repeat("0", digits);

                zeroResultStrings.AddRange(floatZeros);

                return zeroResultStrings.Join(string.Empty).ToDecimal();
            }

            if (fillDigits > 0)
            {
                var fillTailZeroMultipler = GenerateFillTailZeroMultipler(fillDigits);

                var fixAndFillTailZero = fixValue * fillTailZeroMultipler;

                return fixAndFillTailZero;
            }

            return fixValue;
        }

        /// <summary>
        /// 四捨五入
        /// </summary>
        public static decimal ToFix(this decimal input, int digits)
        {
            return decimal.Round(input, digits, MidpointRounding.AwayFromZero);
        }

        /// <summary>
        /// 給定 2，就會產生 1.00m
        /// </summary>
        private static decimal GenerateFillTailZeroMultipler(int digits)
        {
            if (digits <= 0)
            {
                return 0m;
            }

            var digitList = new List<string> { "1", "." };
            digitList.AddRange(Enumerable.Repeat("0", digits));

            var dInString = digitList.Join(string.Empty);

            return decimal.Parse(dInString);
        }

        public static string Join(this IEnumerable<string> input, string delimiter)
        {
            return string.Join(delimiter, input);
        }

        public static decimal ToDecimal(this string input)
        {
            if (decimal.TryParse(input, out decimal result))
            {
                return result;
            }

            return 0;
        }

        public static decimal? ToNullableDecimal(this string input)
        {
            if (decimal.TryParse(input, out decimal result))
            {
                return result;
            }

            return null;
        }
    }
}
