using Microsoft.AspNetCore.Mvc;
using TatBlog.Services.Blogs;

namespace TatBlog.WebApp.Components
{
    public class FeaturedPostsWidget : ViewComponent
    {
        private readonly IBlogRepository _blogRepository;

        public FeaturedPostsWidget(IBlogRepository blogRepository) => _blogRepository = blogRepository;

        public async Task<IViewComponentResult> InvokeAsync() => View(await _blogRepository.GetPopularArticleAsync(numPosts: 3));
    }
}
