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
            vueDto.Data.SubTotal = 0m;

            vueDto.Data.Details
              .ForEach(d =>
                       {
                           d.Amount    =  d.UnitPrice * d.Count;
                           vueDto.Data.SubTotal += d.Amount;
                       });

            vueDto.Data.BusinessTax = vueDto.Data.SubTotal * 0.5m;

            vueDto.Data.Total = vueDto.Data.SubTotal + vueDto.Data.BusinessTax;

            // 四捨五入及補 0

            var fixDigits = CommonExtensions.ToFloatPrecisionDigit(vueDto.Data.FloatPrecision.GetValueOrDefault());
            vueDto.Data.Details
              .ForEach(d =>
                       {
                           d.UnitPrice = d.UnitPrice?.ToFixAndFillTailZero(fixDigits);
                           d.Amount    = d.Amount?.ToFixAndFillTailZero(fixDigits);
                       });

            vueDto.Data.SubTotal    = vueDto.Data.SubTotal?.ToFixAndFillTailZero(fixDigits);
            vueDto.Data.BusinessTax = vueDto.Data.BusinessTax?.ToFixAndFillTailZero(fixDigits);
            vueDto.Data.Total       = vueDto.Data.Total?.ToFixAndFillTailZero(fixDigits);
        }
    }
}
