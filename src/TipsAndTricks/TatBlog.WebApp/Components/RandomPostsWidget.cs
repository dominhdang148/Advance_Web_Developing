using Microsoft.AspNetCore.Mvc;
using TatBlog.Services.Blogs;

namespace TatBlog.WebApp.Components
{
    public class RandomPostsWidget : ViewComponent
    {
        private readonly IBlogRepository _blogRepository;

        public RandomPostsWidget(IBlogRepository blogRepository) => _blogRepository = blogRepository;

        public async Task<IViewComponentResult> InvokeAsync() => View(await _blogRepository.GetRandomPostsAsync(number: 5));

    }
}
