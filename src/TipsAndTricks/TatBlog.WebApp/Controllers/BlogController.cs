using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
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
            [FromQuery(Name ="k")] string keyword = null,
            [FromQuery(Name = "p")] int PageNumber = 1,
            [FromQuery(Name = "ps")] int PageSize = 10)
        {

            var postQuery = new PostQuery()
            {
                PublishedOnly = true,

                Keyword = keyword
            };

            var postList = await _BlogRepository.GetPagedPostAsync(postQuery, PageNumber, PageSize);

            ViewBag.PostQuery = postQuery;
            return View(postList);

        }

        public IActionResult Author(string slug)
        {

            var postQuery=new PostQuery()
            {

            }

            return View();
        }

        public IActionResult Category(string slug)
        {
            return View();
        }


        public IActionResult Tag(string slug)
        {
            return View();
        }
        public IActionResult Post(int year, int month, int day, string slug)
        {
            return View();
        }
        public IActionResult Archives(int year, int month)
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Rss() => Content("Nội dung sẽ được cập nhật");
    }
}
