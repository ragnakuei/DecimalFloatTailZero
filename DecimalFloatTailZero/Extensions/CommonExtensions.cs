using System.Text.Json;

namespace DecimalFloatTailZero.Extensions
{
    public static class CommonExtensions
    {
        public static string ToJson(this object obj)
        {
            return JsonSerializer.Serialize(obj);
        }
    }
}