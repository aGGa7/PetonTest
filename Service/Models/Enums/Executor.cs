using System.Text.Json.Serialization;

namespace Service.Models.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Executor
    {
        Sub1,
        Sub2,
    }
}
