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
        public string Id { get; set; }
        public string Author { get; set; }
        public string Url { get; set; }
        [JsonPropertyName("img")]
        public string Image { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int[] Ratings { get; set; }

        //public override string ToString() => JsonSerializer.Serialize<Article>(this);

        public override string ToString()
        {
            return JsonSerializer.Serialize<Article>(this);
        }
    }
}
