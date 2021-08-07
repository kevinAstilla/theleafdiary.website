using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace theleafdiary.website.models
{
    public class Plant
    {
        public string name { get; set; }
        public int zoneId { get; set; }
        public string description { get; set; }
        [JsonPropertyName("img")]
        public string image { get; set; }
        public int lightTypeId { get; set; }
        public string soilTypeId { get; set; }
        public int[] careDifficulty { get; set; }

        public override string ToString() => JsonSerializer.Serialize<Plant>(this);
    }
}
