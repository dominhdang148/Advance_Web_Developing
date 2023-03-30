using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using TatBlog.Core.Constants;
using TatBlog.Services.Blogs;

namespace TatBlog.WebApp.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogRepository _BlogRepository;
        private readonly IAuthorRepository _AuthorRepository;
        private readonly ICategoryRepository _CategoryRepository;

        public BlogController(IBlogRepository blogRepository, IAuthorRepository authorRepository, ICategoryRepository categoryRepository)
        {
            _BlogRepository = blogRepository;
            _AuthorRepository = authorRepository;
            _CategoryRepository = categoryRepository;
        }

        public async Task<IActionResult> Index(
            [FromQuery(Name = "k")] string keyword = null,
            [FromQuery(Name = "p")] int PageNumber = 1,
            [FromQuery(Name = "ps")] int PageSize = 10)
        {

            var postQuery = new PostQuery()
            {
                PublishedOnly = 1,

                Keyword = keyword
            };

            var postList = await _BlogRepository.GetPagedPostAsync(postQuery, PageNumber, PageSize);


            ViewBag.PostQuery = postQuery;
            return View(postList);

        }

        public async Task<IActionResult> Author(
            string slug = null,
            [FromQuery(Name = "p")] int PageNumber = 1,
            [FromQuery(Name = "ps")] int PageSize = 5)
        {

            var postQuery = new PostQuery()
            {
                PublishedOnly = 1,
                AuthorSlug = slug
            };
            var postList = await _BlogRepository.GetPagedPostAsync(postQuery, PageNumber, PageSize);

            ViewBag.Author = await _AuthorRepository.GetAuthorBySlugAsync(slug);

            return View(postList);
        }
        
        public async Task<IActionResult> Category(
            string slug = null,
            [FromQuery(Name = "p")] int PageNumber = 1,
            [FromQuery(Name = "ps")] int PageSize = 5)
        {
            var postQuery = new PostQuery()
            {
                PublishedOnly = 1,
                CategorySlug = slug
            };
            var postList = await _BlogRepository.GetPagedPostAsync(postQuery, PageNumber, PageSize);

            ViewBag.Category = await _CategoryRepository.GetCategoryBySlugAsync(slug);

            return View(postList); 
        }


        public async Task<IActionResult> Tag(
            string slug = null,
            [FromQuery(Name = "p")] int PageNumber = 1,
            [FromQuery(Name = "ps")] int PageSize = 5)
        {

            var postQuery = new PostQuery()
            {
                PublishedOnly = 1,
                TagSlug = slug
            };

            var postList = await _BlogRepository.GetPagedPostAsync(postQuery, PageNumber, PageSize);

            ViewBag.Tag = await _BlogRepository.FindTag_SlugAsync(slug);
            return View(postList);
        }

        public async Task<IActionResult> Post(int year, int month, int day, string slug)
        {
            var post = await _BlogRepository.GetPostAsync(year, month, day, slug);
            await _BlogRepository.IncreaseViewCountAsync(post.Id);
            return View(post);
        }
        public async Task<IActionResult> Archives(
            int year, 
            int month,
            [FromQuery(Name = "p")] int PageNumber = 1,
            [FromQuery(Name = "ps")] int PageSize = 5)
        {

            var postQuery = new PostQuery()
            {
                PostedMonth = month,
                PostedYear = year,
            };

            var postList = await _BlogRepository.GetPagedPostAsync(postQuery,PageNumber,PageSize);

            ViewBag.Month = month;
            ViewBag.Year = year; 

            return View(postList);
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
