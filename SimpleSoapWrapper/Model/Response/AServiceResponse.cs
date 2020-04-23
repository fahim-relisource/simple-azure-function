using Newtonsoft.Json;

namespace SimpleSoapWrapper.Model.Response
{
    public abstract class AServiceResponse
    {
        [JsonProperty(propertyName: "success")]
        public bool Success = true;

        [JsonProperty(propertyName: "message")]
        public string Message = "";
    }
}