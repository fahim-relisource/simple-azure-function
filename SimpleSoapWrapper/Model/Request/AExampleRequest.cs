using Newtonsoft.Json;

namespace SimpleSoapWrapper.Model.Request
{
    public abstract class AExampleRequest : AServiceRequest
    {
        [JsonProperty(propertyName: "find-person")]
        public bool FindPerson { get; set; }
        [JsonProperty(propertyName: "find-all-person")]
        public bool FindAllPerson { get; set; }
        [JsonProperty(propertyName: "find-address")]
        public bool FindAddress { get; set; }
    }
}
