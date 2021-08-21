using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using theleafdiary.website.models;
using theleafdiary.WebSite.Services;

namespace theleafdiary.website.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ArticlesController : ControllerBase
    {
        public JsonFileArticleService ArticleService { get; }
        public ArticlesController(JsonFileArticleService ArticleService)
        {
            this.ArticleService = ArticleService;
        }
        [HttpGet]
        public IEnumerable<Article> Get()
        {
            return ArticleService.GetArticles();
        }
        [HttpGet]
        public ActionResult Get(
            [FromQuery] string ProductId,
            [FromQuery] int Rating)
        {
            ArticleService.AddRating(ProductId, Rating);
            return Ok();
        }
    }
}
