using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace theleafdiary.website.models
{
    public class Article
    {
        public string id { get; set; }
        public string author { get; set; }
        public string url { get; set; }
        [JsonPropertyName("img")]
        public string image { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public int[] ratings { get; set; }

        //public override string ToString() => JsonSerializer.Serialize<Article>(this);

        public override string ToString()
        {
            return JsonSerializer.Serialize<Article>(this);
        }
    }
}
