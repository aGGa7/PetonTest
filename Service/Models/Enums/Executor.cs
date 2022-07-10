using System.Text.Json.Serialization;

namespace Service.Models.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Executor
    {
        Pethon,
        Sub1,
    }
}
