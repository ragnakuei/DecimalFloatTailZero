using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DecimalFloatTailZero.Infra
{
    public class StringNullableDecimalJsonConverter : JsonConverter<decimal?>
    {
        public override decimal? Read(ref Utf8JsonReader    reader,
                                      Type                  typeToConvert,
                                      JsonSerializerOptions options)
        {
            if (Decimal.TryParse(reader.GetString(), out var result))
            {
                return result;
            }

            return null;
        }

        public override void Write(Utf8JsonWriter        writer,
                                   decimal?              nullableDecimal,
                                   JsonSerializerOptions options) =>
            writer.WriteStringValue(nullableDecimal.ToString());
    }
}