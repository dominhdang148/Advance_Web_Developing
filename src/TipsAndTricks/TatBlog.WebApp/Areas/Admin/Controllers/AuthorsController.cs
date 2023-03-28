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
        private readonly IAuthorRepository _authorRepository;
    

        public AuthorsController(IBlogRepository blogRepository, IAuthorRepository authorRepository)
        {
            _blogRepository = blogRepository;
            _authorRepository = authorRepository;
        }

        public async Task<IActionResult> Index(AuthorFilterModel model)
        {
            var authorQuery = new AuthorQuery()
            {
                Keyword = model.Keyword,
            };

            ViewBag.AuthorsList = await _authorRepository.GetAuthor_KeywordAsync(authorQuery);

            return View(model);
        }

        public async Task<IActionResult> DeleteAuthor(int id)
        {
            await _authorRepository.DeleteAuthorAsync(id);
            return RedirectToAction("Index");
        }
    }
}
