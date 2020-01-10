using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using SeafileClient.Utils;

namespace SeafileClient.Common.Converters
{
    public class TimestampConverter: JsonConverter<DateTime>
    {
        public override DateTime Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options) =>
                DateUtils.TimestampToDateTime(reader.GetInt64());

        public override void Write(
            Utf8JsonWriter writer,
            DateTime value,
            JsonSerializerOptions options) =>
                writer.WriteNumberValue(DateUtils.DateTimeToTimestamp(value));
    }
}
