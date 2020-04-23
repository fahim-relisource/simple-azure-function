using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace SimpleSoapWrapper.Model
{
    public class SimplePerson
    {
        [JsonProperty(propertyName: "id")]
        public int Id { get; set; }
        [JsonProperty(propertyName: "name")]
        public string Name { get; set; }
        [JsonProperty(propertyName: "ssn")]
        public string SSN { get; set; }
        [JsonProperty(propertyName: "dob")]
        public DateTime DOB { get; set; }
    }
}