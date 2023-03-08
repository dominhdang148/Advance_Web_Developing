using Microsoft.AspNetCore.Mvc;
using TatBlog.Core.Constants;
using TatBlog.Services.Blogs;

namespace TatBlog.WebApp.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogRepository _BlogRepository;

        public BlogController(IBlogRepository blogRepository)
        {
            _BlogRepository = blogRepository;
        }

        public async Task<IActionResult> Index(
            [FromQuery(Name = "p")] int PageNumber = 1,
            [FromQuery(Name = "ps")] int PageSize = 10)
        {

            var postQuery = new PostQuery()
            {
                PublishedOnly = true,
            };

            var postList = await _BlogRepository.GetPagedPostAsync(postQuery, PageNumber, PageSize);

            ViewBag.PostQuery = postQuery;
            return View(postList);

        }

        public IActionResult About() => View();
        public IActionResult Contact() => View();
        public IActionResult Rss() => Content("Nội dung sẽ được cập nhật");
    }
}
