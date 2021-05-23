using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CityFinder.Models
{
    public partial class GeocodeApiErrorResponse
    {
        [JsonProperty("error_message")]
        public string ErrorMessage { get; set; }

        [JsonProperty("results")]
        public List<object> Results { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }

    public partial class GeocodeApiErrorResponse
    {
        public static GeocodeApiErrorResponse FromJson(string json) => JsonConvert.DeserializeObject<GeocodeApiErrorResponse>(json, JsonConverter.Settings);
    }
}
