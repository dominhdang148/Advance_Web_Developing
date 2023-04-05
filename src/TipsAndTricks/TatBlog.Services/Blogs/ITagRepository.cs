using TatBlog.Core.Constants;
using TatBlog.Core.Contracts;
using TatBlog.Core.DTO;
using TatBlog.Core.Entities;

namespace TatBlog.Services.Blogs
{
    public interface ITagRepository
    {
        Task<Tag> GetTagBySlugAsync(
            string slug,
            CancellationToken cancellation = default);
        Task<Tag> GetTagByIdAsync(int id);
        Task<Tag> GetCacheCategoryBySlugAsync(string slug);
        Task<Tag> GetCachedCategoryByIdAsync(int id);
        Task<IList<TagItem>> GetTagsAsync(CancellationToken cancellationToken = default);
        Task<IPagedList<TagItem>> GetPagedTagsAsync(
            IPagingParams pagingParams,
            string name = null,
            CancellationToken cancellation = default);
        Task<IPagedList<T>> GetPagedTagsAsync<T>(
            Func<IQueryable<Tag>, IQueryable<T>> mapper,
            IPagingParams pagingParams,
            string name = null,
            CancellationToken cancellation = default);
        Task<bool> AddOrUpdateTagAsync(
            Tag tag,
            CancellationToken cancellation = default);
        Task<bool> DeleteTagAsync(
            int tagId,
            CancellationToken cancellation = default);

        Task<bool> IsTagSlugExistedAsync(
            int tagId,
            string slug,
            CancellationToken cancellation = default);

        //=========================================

        Task<IList<TagItem>> GetTags_KeywordAsync(TagQuery condition, CancellationToken cancellationToken = default);

    }
}
