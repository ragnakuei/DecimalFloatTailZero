using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using DecimalFloatTailZero.Extensions;

namespace DecimalFloatTailZero.Infra
{
    public class StringToNullableDecimalJsonConverter : JsonConverter<decimal?>
    {
        public override decimal? Read(ref Utf8JsonReader    reader,
                                      Type                  typeToConvert,
                                      JsonSerializerOptions options) =>
            reader.GetString().ToNullableDecimal();

        public override void Write(Utf8JsonWriter        writer,
                                   decimal?              decimalValue,
                                   JsonSerializerOptions options) =>
            writer.WriteStringValue(decimalValue?.ToString());
    }
}
