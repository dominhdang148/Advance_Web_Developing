using Microsoft.AspNetCore.Mvc;
using TatBlog.Services.Blogs;
using TatBlog.WebApp.Areas.Admin.Models;

namespace TatBlog.WebApp.Areas.Admin.Controllers
{
    public class AuthorsController:Controller
    {
        private readonly IBlogRepository _blogRepository;

        public AuthorsController(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }
        public async Task<IActionResult> Index(AuthorFilterModel model)
        {
            string keyword = model.Keyword;

            ViewBag.AuthorsList= await _blogRepository.GetAuthor_KeywordAsync(keyword);

            return View(model);
        }
    }
}
