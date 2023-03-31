using TatBlog.Core.Collections;
using TatBlog.Core.DTO;
using TatBlog.Services.Blogs;
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
    }
}
