using System.Text.Json.Serialization;
using DecimalFloatTailZero.Infra;

namespace DecimalFloatTailZero.Models
{
    public class VueDto<T>
    {
        public T Data { get; set; }
    }
}
