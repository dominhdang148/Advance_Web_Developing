using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using TatBlog.Core.Constants;
using TatBlog.Services.Blogs;
using TatBlog.WebApp.Areas.Admin.Models;

namespace TatBlog.WebApp.Areas.Admin.Controllers
{
    public class AuthorsController : Controller
    {

        private readonly IBlogRepository _blogRepository;
    

        public AuthorsController(IBlogRepository blogRepository )
        {
            _blogRepository = blogRepository;
        
        }

        public async Task<IActionResult> Index(AuthorFilterModel model)
        {
            var authorQuery = new AuthorQuery()
            {
                Keyword = model.Keyword,
            };

            ViewBag.AuthorsList = await _blogRepository.GetAuthor_KeywordAsync(authorQuery);

            return View(model);
        }

        public async Task<IActionResult> DeleteAuthor(int id)
        {
            await _blogRepository.DeleteAuthorAsync(id);
            return RedirectToAction("Index");
        }
    }
}
