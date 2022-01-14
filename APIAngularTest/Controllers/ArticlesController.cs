using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using APIAngularTest.Data;
using APIAngularTest.Models;

namespace APIAngularTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArticlesController : Controller
    {
        private readonly APIAngularTestContext _context;

        public ArticlesController(APIAngularTestContext context)
        {
            _context = context;
        }

        //[Bind("ID,Title,Content,Author,CreatedAt,URL")] Article article

        [HttpPost]
        [Route("new")]
        public async Task<IActionResult> CreateArticle([Bind("Title,Content,Author")] CreateArticleRequest article)
        {
            var newArticle = new Article();
            newArticle.Author = article.Author;
            newArticle.Content = article.Content;
            newArticle.Title = article.Title;
            newArticle.CreatedAt = DateTime.UnixEpoch.Ticks;
            newArticle.URL = "";

            await _context.AddAsync(newArticle);
            await _context.SaveChangesAsync();

            var result = new OkObjectResult(newArticle);
            return result;
        }

        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> ListArticles()
        {
            var articles = await _context.Article.ToListAsync();

            var result = new OkObjectResult(articles);
            return result;
        }

        [HttpGet]
        [Route("ping")]
        public async Task<IActionResult> Ping()
        {
            var task = Task.Run(() =>
            {
                var respone = new PingResponse()
                {
                    Ticks = DateTime.UnixEpoch.Ticks,
                    Status = "success"
                };
                var result = new OkObjectResult(respone);

                return result;
            });

            return await task;
        }
    }
}
