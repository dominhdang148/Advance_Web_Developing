using Microsoft.AspNetCore.Mvc;
using TatBlog.Services.Blogs;

namespace TatBlog.WebApp.Components
{
    public class TagCloudWidget : ViewComponent
    {
        private readonly ITagRepository _tagRepository;

        public TagCloudWidget(ITagRepository tagRepository) => _tagRepository = tagRepository;

        public async Task<IViewComponentResult> InvokeAsync() => View(await _tagRepository.GetTagsAsync());

      
    }
}