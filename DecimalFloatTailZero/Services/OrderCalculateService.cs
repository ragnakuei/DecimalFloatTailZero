using System.Globalization;
using System.Runtime.Intrinsics.X86;
using DecimalFloatTailZero.Models;
using DecimalFloatTailZero.Extensions;

namespace DecimalFloatTailZero.Services
{
    public class OrderCalculateService
    {
        public void ReCalculate(VueDto<OrderDto> vueDto)
        {
            vueDto.Data.SubTotalDecimal = 0m;

            vueDto.Data.Details
                  .ForEach(d =>
                           {
                               d.AmountDecimal             =  d.UnitPriceDecimal * d.Count;
                               vueDto.Data.SubTotalDecimal += d.AmountDecimal;
                           });

            vueDto.Data.BusinessTaxDecimal = vueDto.Data.SubTotalDecimal * 0.5m;

            vueDto.Data.TotalDecimal = vueDto.Data.SubTotalDecimal + vueDto.Data.BusinessTaxDecimal;

            // 四捨五入及補 0

            var fixDigits = CommonExtensions.ToFloatPrecisionDigit(vueDto.Data.FloatPrecisionDecimal.GetValueOrDefault());
            vueDto.Data.Details
                  .ForEach(d =>
                           {
                               d.UnitPriceDecimal = d.UnitPriceDecimal?.ToFixAndFillTailZero(fixDigits);
                               d.AmountDecimal    = d.AmountDecimal?.ToFixAndFillTailZero(fixDigits);
                           });

            vueDto.Data.SubTotalDecimal    = vueDto.Data.SubTotalDecimal?.ToFixAndFillTailZero(fixDigits);
            vueDto.Data.BusinessTaxDecimal = vueDto.Data.BusinessTaxDecimal?.ToFixAndFillTailZero(fixDigits);
            vueDto.Data.TotalDecimal       = vueDto.Data.TotalDecimal?.ToFixAndFillTailZero(fixDigits);
        }
    }
}
