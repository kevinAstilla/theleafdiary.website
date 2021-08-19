using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using theleafdiary.website.models;
using theleafdiary.WebSite.Services;

namespace theleafdiary.website.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public JsonFileArticleService ArticleService;
        public IEnumerable<Article> Articles { get; private set; }

        public IndexModel(
            ILogger<IndexModel> logger,
            JsonFileArticleService articleService
            )
        {
            _logger = logger;
            ArticleService = articleService;
        }

        public void OnGet()
        {
            Articles = ArticleService.GetArticles();
        }
    }
}
