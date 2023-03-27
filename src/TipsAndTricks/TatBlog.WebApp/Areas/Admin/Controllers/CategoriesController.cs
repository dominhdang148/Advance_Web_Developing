using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using TatBlog.Core.Constants;
using TatBlog.Core.Entities;
using TatBlog.Services.Blogs;
using TatBlog.WebApp.Areas.Admin.Models;

namespace TatBlog.WebApp.Areas.Admin.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IMapper _mapper;
        public CategoriesController(IBlogRepository blogRepository, IMapper mapper)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index(CategoryFilterModel model)
        {

            //CategoryQuery query = new CategoryQuery()
            //{
            //    Keyword = model.Keyword,
            //    ShowOnMenu = model.ShowOnMenu,
            //};

            var query = _mapper.Map<CategoryQuery>(model);

            ViewBag.CategoriesList = await _blogRepository.GetCategoriesWithConditionAsync(query);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id = 0)
        {
            var category = id > 0 ?
                await _blogRepository.FindCategory_IdAsync(id)
                : null;

            var model = category == null
                ? new CategoryEditModel()
                : _mapper.Map<CategoryEditModel>(category);

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(CategoryEditModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var category = model.Id > 0
                ? await _blogRepository.FindCategory_IdAsync(model.Id) : null;

            if (category == null)
            {
                category = _mapper.Map<Category>(model);

                category.Id = 0;
            }
            else
            {
                _mapper.Map(model, category);
            }
            await _blogRepository.CreateOrUpdateCategoryAsync(category);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DeleteCategory(int id = 0)
        {
            await _blogRepository.Delete_CategoryAsync(id); 
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> ToggleShowOnMenu(int id = 0)
        {
            await _blogRepository.ToggleShowOnMenuFlagAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
