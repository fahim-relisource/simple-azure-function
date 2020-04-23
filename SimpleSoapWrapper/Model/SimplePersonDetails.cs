using Newtonsoft.Json;

namespace SimpleSoapWrapper.Model
{
    public class SimplePersonDetails : SimplePerson
    {
        [JsonProperty(propertyName: "age")] public int Age { get; set; }

        [JsonProperty(propertyName: "fav-colors")]
        public string FavoriteColors { get; set; }
        [JsonProperty(propertyName: "office")] public string OfficeAddress { get; set; }
        [JsonProperty(propertyName: "home")] public string HomeAddress { get; set; }
    }
}