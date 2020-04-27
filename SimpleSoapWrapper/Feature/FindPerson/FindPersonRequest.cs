using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using SimpleSoapWrapper.Model.Request;

namespace SimpleSoapWrapper.Feature.FindPerson
{
    public class FindPersonRequest : AServiceRequest
    {
        [JsonProperty(propertyName:"person-id")]
        public int PersonId { get; set; }
    }
}
