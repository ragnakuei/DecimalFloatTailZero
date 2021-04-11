using System.Globalization;
using System.Runtime.Intrinsics.X86;
using DecimalFloatTailZero.Models;
using DecimalFloatTailZero.Extensions;

namespace DecimalFloatTailZero.Services
{
    public class OrderCalculateService
    {
        public void ReCalculate(OrderDto vm)
        {
            vm.SubTotal = 0m;

            vm.Details
              .ForEach(d =>
                       {
                           d.Amount    =  d.UnitPrice * d.Count;
                           vm.SubTotal += d.Amount;
                       });

            vm.BusinessTax = vm.SubTotal * 0.5m;

            vm.Total = vm.SubTotal + vm.BusinessTax;

            // 四捨五入及補 0

            var fixDigits = 4;
            vm.Details
              .ForEach(d =>
                       {
                           d.UnitPrice = d.UnitPrice?.ToFixAndFillTailZero(fixDigits);
                           d.Amount    = d.Amount?.ToFixAndFillTailZero(fixDigits);
                       });

            vm.SubTotal    = vm.SubTotal?.ToFixAndFillTailZero(fixDigits);
            vm.BusinessTax = vm.BusinessTax?.ToFixAndFillTailZero(fixDigits);
            vm.Total       = vm.Total?.ToFixAndFillTailZero(fixDigits);
        }
    }
}
