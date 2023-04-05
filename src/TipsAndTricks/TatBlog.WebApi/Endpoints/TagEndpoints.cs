using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using TatBlog.Core.Collections;
using TatBlog.Core.Constants;
using TatBlog.Core.DTO;
using TatBlog.Core.Entities;
using TatBlog.Services.Blogs;
using TatBlog.WebApi.Filters;
using TatBlog.WebApi.Models;

namespace TatBlog.WebApi.Endpoints
{
    public static class TagEndpoints
    {
        public static WebApplication MapTagEndpoints(this WebApplication app)
        {
            var routeGroupBuilder = app.MapGroup("/api/tags");

            routeGroupBuilder.MapGet("/", GetTags)
                .WithName("GetTags")
                .Produces<PaginationResult<TagItem>>();


            routeGroupBuilder.MapGet("/{id:int}", GetTagId)
                .WithName("GetTagById")
                .Produces<TagItem>()
                .Produces(404);

            routeGroupBuilder.MapGet("/{slug:regex(^[a-z0-9_-]+$)}/posts", GetPostsByTagSlug)
                .WithName("GetPostsByTagSlug")
                .Produces<PaginationResult<PostDto>>();

            routeGroupBuilder.MapPost("/", AddTag)
                .WithName("AddNewTag")
                .AddEndpointFilter<ValidatorFilter<TagEditModel>>()
                .Produces(201)
                .Produces(400)
                .Produces(409);

            routeGroupBuilder.MapPut("/{id:int}", UpdateTag)
               .WithName("UpdateTag")
               .AddEndpointFilter<ValidatorFilter<TagEditModel>>()
               .Produces(204)
               .Produces(400)
               .Produces(409);
            routeGroupBuilder.MapDelete("/{id:int}", DeleteTag)
                .WithName("DeleteTag")
                .Produces(204)
                .Produces(404);

            return app;
        }


        private static async Task<IResult> GetTags(
            [AsParameters] TagFilterModel model,
            ITagRepository tagRepository)
        {
            var tagsList = await tagRepository.GetPagedTagsAsync(model, model.Name);
            var pagingationResult = new PaginationResult<TagItem>(tagsList);
            return Results.Ok(pagingationResult);
        }

        private static async Task<IResult> GetTagId(
           int id,
           ITagRepository tagRepository,
           IMapper mapper)
        {
            var category = await tagRepository.GetCachedCategoryByIdAsync(id);
            return category == null
                ? Results.NotFound($"")
                : Results.Ok(mapper.Map<CategoryItem>(category));
        }

        private static async Task<IResult> GetPostsByTagSlug(
            [FromRoute] string slug,
            [AsParameters] PagingModel pagingModel,
            IBlogRepository blogRepository)
        {
            var postQuery = new PostQuery()
            {
                TagSlug = slug,
                PublishedOnly = 1
            };

            var postsList = await blogRepository.GetPagedPostsAsync(
                postQuery, pagingModel,
                posts => posts.ProjectToType<PostDto>());

            var paginationResult = new PaginationResult<PostDto>(postsList);

            return Results.Ok(paginationResult);

        }

        private static async Task<IResult> AddTag(
            TagEditModel model,
            ITagRepository tagRepository,
            IMapper mapper)
        {

            if (await tagRepository.IsTagSlugExistedAsync(0, model.UrlSlug))
            {
                return Results.Conflict(
                    $"Slug '{model.UrlSlug}' đã được sử dụng");
            }
            var tag = mapper.Map<Tag>(model);
            await tagRepository.AddOrUpdateTagAsync(tag);

            return Results.CreatedAtRoute(
                "GetTagById", new {tag.Id },
                mapper.Map<CategoryItem>(tag));
        }

        private static async Task<IResult> UpdateTag(
           int id, TagEditModel model,

           ITagRepository tagRepository,
           IMapper mapper)
        {


            if (await tagRepository.IsTagSlugExistedAsync(id, model.UrlSlug))
            {
                return Results.Conflict($"Slug '{model.UrlSlug}' đã đuọc sử dụng");
            }
            var tag = mapper.Map<Tag>(model);
            tag.Id = id;

            return await tagRepository.AddOrUpdateTagAsync(tag)
                ? Results.NoContent()
                : Results.NotFound();

        }


        private static async Task<IResult> DeleteTag(
            int id, ITagRepository tagRepository)
        {
            return await tagRepository.DeleteTagAsync(id)
                ? Results.NoContent()
                : Results.NotFound($"Could not find category with id = {id}");
        }
    }
}
