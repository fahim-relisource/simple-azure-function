using Newtonsoft.Json;

namespace SimpleSoapWrapper.Model.Response
{
    public class SimpleResponse : AServiceResponse
    {
        [JsonProperty(propertyName: "person")]
        public object Person { get; set; }
        [JsonProperty(propertyName: "person-list")]
        public object PersonList { get; set; }
        [JsonProperty(propertyName: "address")]
        public object Address { get; set; }
    }
}
