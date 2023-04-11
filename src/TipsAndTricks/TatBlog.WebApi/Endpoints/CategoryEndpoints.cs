using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TatBlog.Core.Collections;
using TatBlog.Core.Constants;
using TatBlog.Core.DTO;
using TatBlog.Core.Entities;
using TatBlog.Services.Blogs;
using TatBlog.WebApi.Filters;
using TatBlog.WebApi.Models;

namespace TatBlog.WebApi.Endpoints
{
    public static class CategoryEndpoints
    {
        public static WebApplication MapCategoryEndpoints(this WebApplication app)
        {
            var routeGroupBuilder = app.MapGroup("/api/categories");

            routeGroupBuilder.MapGet("/", GetCategoriesWithoutParameter)
                .WithName("GetCategories")
                .Produces<ApiResponse<CategoryItem>> ();


            routeGroupBuilder.MapGet("/{id:int}", GetGategoryId)
                .WithName("GetCategoryById")
                .Produces<ApiResponse<CategoryItem>>();


            routeGroupBuilder.MapGet("/{slug:regex(^[a-z0-9_-]+$)}/posts", GetPostsByCategorySlug)
                .WithName("GetPostsByCategorySlug")
                .Produces<PaginationResult<PostDto>>();

            routeGroupBuilder.MapPost("/", AddCategory)
                .WithName("AddNewCategory")
                .AddEndpointFilter<ValidatorFilter<CategoryEditModel>>()
                .Produces(201)
                .Produces(400)
                .Produces(409);

            routeGroupBuilder.MapPut("/{id:int}", UpdateCategory)
               .WithName("UpdateCategory")
               .AddEndpointFilter<ValidatorFilter<CategoryEditModel>>()
               .Produces(204)
               .Produces(400)
               .Produces(409);
            routeGroupBuilder.MapDelete("/{id:int}", DeleteCategory)
                .WithName("DeleteCategory")
                .Produces(204)
                .Produces(404);

            return app;
        }

        private static async Task<IResult> GetCategories(
            [AsParameters] CategoryFilterModel model,
            ICategoryRepository categoryRepository)
        {
            var categoriesList = await categoryRepository.GetPagedCategoriesAsync(model, model.Name);
            var paginationResult = new PaginationResult<CategoryItem>(categoriesList);
            return Results.Ok(ApiResponse.Success(paginationResult));
        }

        private static async Task<IResult> GetCategoriesWithoutParameter(
            ICategoryRepository categoryRepository) => Results.Ok(ApiResponse.Success(await categoryRepository.GetCategoriesAsync()));

        private static async Task<IResult> GetGategoryId(
            int id,
            ICategoryRepository categoryRepository,
            IMapper mapper)
        {
            var category = await categoryRepository.GetCachedCategoryByIdAsync(id);
            return category == null
                ? Results.Ok(ApiResponse.Fail(HttpStatusCode.NotFound, "Không tìm thấy danh mục"))
                : Results.Ok(ApiResponse.Success(mapper.Map<CategoryItem>(category)));
        }

        private static async Task<IResult> GetPostsByCategorySlug(
            [FromRoute] string slug,
            [AsParameters] PagingModel pagingModel,
            IBlogRepository blogRepository)
        {
            var postQuery = new PostQuery()
            {
                CategorySlug = slug,
                PublishedOnly = 1
            };

            var postsList = await blogRepository.GetPagedPostsAsync(
                postQuery, pagingModel,
                posts => posts.ProjectToType<PostDto>());

            var paginationResult = new PaginationResult<PostDto>(postsList);

            return Results.Ok(paginationResult);

        }

        private static async Task<IResult> AddCategory(
            CategoryEditModel model,
            ICategoryRepository categoryRepository,
            IMapper mapper)
        {

            if (await categoryRepository.IsCategorySlugExitstedAsync(0, model.UrlSlug))
            {
                return Results.Conflict(
                    $"Slug '{model.UrlSlug}' đã được sử dụng");
            }
            var category = mapper.Map<Category>(model);
            await categoryRepository.AddOrUpdateCategoryAsync(category);

            return Results.CreatedAtRoute(
                "GetCategoryById", new { category.Id },
                mapper.Map<CategoryItem>(category));
        }

        private static async Task<IResult> UpdateCategory(
           int id, CategoryEditModel model,

           ICategoryRepository categoryRepository,
           IMapper mapper)
        {


            if (await categoryRepository.IsCategorySlugExitstedAsync(id, model.UrlSlug))
            {
                return Results.Conflict($"Slug '{model.UrlSlug}' đã đuọc sử dụng");
            }
            var category = mapper.Map<Category>(model);
            category.Id = id;

            return await categoryRepository.AddOrUpdateCategoryAsync(category)
                ? Results.NoContent()
                : Results.NotFound();

        }


        private static async Task<IResult> DeleteCategory(
            int id, ICategoryRepository categoryRepository)
        {
            return await categoryRepository.DeleteCategoryAsync(id)
                ? Results.NoContent()
                : Results.NotFound($"Could not find category with id = {id}");
        }
    }
}
