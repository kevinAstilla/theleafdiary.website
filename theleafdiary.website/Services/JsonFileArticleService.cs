using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Microsoft.AspNetCore.Hosting;
using theleafdiary.website.models;

namespace theleafdiary.WebSite.Services
{
    public class JsonFileArticleService
    {
        public JsonFileArticleService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }

        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "articles.json"); }
        }

        public IEnumerable<Article> GetArticles()
        {
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<Article[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
            }
        }
        public void AddRating(string articleId, int ratings)
        {
            var articles = GetArticles();

            var article = articles.First( x => x.Id == articleId);

            if(article.Ratings == null)
            {
                article.Ratings = new int[] { ratings };
            }
            else
            {
                var articleRatings = article.Ratings.ToList();
                articleRatings.Add(ratings);
                article.Ratings = articleRatings.ToArray();
            }

            using(var outputStream = File.OpenWrite(JsonFileName))
            {
                JsonSerializer.Serialize<IEnumerable<Article>>(
                    new Utf8JsonWriter(outputStream, new JsonWriterOptions
                    {
                        SkipValidation = true,
                        Indented = true
                    }),
                    articles
                );
            }
        }
    }
}