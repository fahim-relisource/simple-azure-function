using Newtonsoft.Json;

namespace SimpleSoapWrapper.Model.Request
{
    public abstract class AServiceRequest
    {
        [JsonProperty(propertyName: "api-key")]
        public string ApiKey { get; set; }
    }
}
