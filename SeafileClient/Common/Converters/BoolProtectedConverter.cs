using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SeafileClient.Common.Converters
{
    class BoolProtectedConverter : JsonConverter<bool>
    {
        public override bool Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options) {
            try
            {
                return reader.GetBoolean();
            } 
            catch (InvalidOperationException)
            {
                return false;
            }
        }

        public override void Write(
            Utf8JsonWriter writer,
            bool value,
            JsonSerializerOptions options) =>
                writer.WriteBooleanValue(value);
    }
}
