using System;
using Newtonsoft.Json;

namespace WordCounter.Common
{
    [JsonObject(Title = "business_message")]
    public class BusinessMessage
    {
        [JsonProperty(PropertyName = "content")]
        public string Content { get; set; }

        [JsonProperty(PropertyName = "correlation_id")]
        public Guid CorrelationId { get; set; }
    }
}
