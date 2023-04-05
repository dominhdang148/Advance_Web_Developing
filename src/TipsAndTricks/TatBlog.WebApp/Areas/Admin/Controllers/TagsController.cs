using Microsoft.AspNetCore.Mvc;
using TatBlog.Core.Constants;
using TatBlog.Services.Blogs;
using TatBlog.WebApp.Areas.Admin.Models;

namespace TatBlog.WebApp.Areas.Admin.Controllers
{
    public class TagsController: Controller
    {
        private readonly IBlogRepository _blogRepository;
        private readonly ITagRepository _tagRepository;


        public TagsController(IBlogRepository blogRepository, ITagRepository tagRepository)
        {
            _blogRepository = blogRepository;
            _tagRepository = tagRepository;
        }

        public async Task<IActionResult> Index(TagFilterModel model)
        {
            var tagQuery = new TagQuery()
            {
                Keyword = model.Keyword
            };
            ViewBag.TagsList= await _tagRepository.GetTags_KeywordAsync(tagQuery);
            return View(model);
        }

        public async Task<IActionResult> DeleteTag(int id)
        {
            await _tagRepository.DeleteTagAsync(id);

            return RedirectToAction("Index");
        }
    }
}
