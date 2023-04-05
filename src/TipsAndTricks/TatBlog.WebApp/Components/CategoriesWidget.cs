using Microsoft.AspNetCore.Mvc;
using TatBlog.Services.Blogs;

namespace TatBlog.WebApp.Components
{
    public class CategoriesWidget : ViewComponent
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoriesWidget(ICategoryRepository categoryRepository) => _categoryRepository = categoryRepository;

        public async Task<IViewComponentResult> InvokeAsync() => View(await _categoryRepository.GetCategoriesAsync());

        //public async Task<IViewComponentResult> InvokeAsync()
        //{
        //    var categories = await _blogRepository.GetCategoriesAsync();

        //    return View(categories);
        //}
    }
}
