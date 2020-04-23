using Newtonsoft.Json;

namespace SimpleSoapWrapper.Model.Request
{
    public class SimpleRequest : AExampleRequest
    {
        [JsonProperty(propertyName: "person-id")]
        public int PersonId { get; set; }
        [JsonProperty(propertyName: "person-name")]
        public string Name { get; set; }
        [JsonProperty(propertyName: "zip-code")]
        public string ZipCode { get; set; }
    }
}
