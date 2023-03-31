using TatBlog.Core.Collections;
using TatBlog.Core.DTO;
using TatBlog.Services.Blogs;
using TatBlog.WebApi.Models;

namespace TatBlog.WebApi.Endpoints
{
    public static class CategoryEndpoints
    {
        public static WebApplication MapCategoryEndpoints(this WebApplication app)
        {
            var routeGroupBuilder = app.MapGroup("/api/categories");

            routeGroupBuilder.MapGet("/", GetCategories)
                .WithName("GetCategories")
                .Produces<PaginationResult<CategoryItem>>();

            return app;
        }

        private static async Task<IResult> GetCategories(
            [AsParameters] AuthorFilterModel model,
            ICategoryRepository categoryRepository)
        {
            var categoriesList = await categoryRepository.GetPagedCategoriesAsync(model, model.Name);

            var paginationResult = new PaginationResult<CategoryItem>(categoriesList);
            return Results.Ok(paginationResult);
        }
    }
}
