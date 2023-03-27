using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TatBlog.Core.Constants;
using TatBlog.Core.Contracts;
using TatBlog.Core.DTO;
using TatBlog.Core.Entities;

namespace TatBlog.Services.Blogs
{
    public interface IBlogRepository
    {
        // Tìm bài viết có tên định danh là 'slug'
        // và được đăng vào tháng 'month' năm 'year'
        Task<Post> GetPostAsync(
            int year,
            int month,
            int day,
            string slug,
            CancellationToken cancellationToken = default);

        // Tìm top N bài viết phiỉe được nhiều người xem nhất
        Task<IList<Post>> GetPopularArticleAsync(
            int numPosts,
            CancellationToken cancellation = default);

        // Kiểm tra xem tên định danh của bài viết có hay chưa
        Task<bool> IsPostSlugExistedAsync(
            int postID, string slug,
            CancellationToken cancellationToken = default);

        // Tăng số lượt xem của một bài viết
        Task IncreaseViewCountAsync(
            int postId,
            CancellationToken cancellationToken = default);

        // Lấy dánh sách chuyên mục và số lượng bài viết
        // nằm thuộc từng chuyên mục/ chủ đề
        Task<IList<CategoryItem>> GetCategoriesAsync(bool showOnMenu = false, CancellationToken cancellationToken = default);

        // Lấy danh sách từ khóa/thẻ và phân trang theo
        // các tham số pagingParam
        Task<IPagedList<TagItem>> GetPagedTagsAsync(IPagingParams pagingParams, CancellationToken cancellationToken = default);

        // Tìm một thẻ theo tên định danh slug
        Task<Tag> FindTag_SlugAsync(string slug, CancellationToken cancellationToken = default);

        // Lấy danh sách các thẻ
        Task<IList<TagItem>> GetAllTagsWithPostAsync(CancellationToken cancellationToken = default);
        // Xóa 1 thẻ theo ID
        Task DeleteTagByIDAsync(int id, CancellationToken cancellationToken = default);
        // Tìm một chuyên mục (Category) theo tên định danh
        Task<Category> FindCategory_SlugAsync(string slug, CancellationToken cancellation = default);
        // Tìm một chuyên mục theo mã số cho trước
        Task<Category> FindCategory_IdAsync(int id, CancellationToken cancellationToken = default);
        // Thêm hoặc cập nhật một chuyên mục (chủ đề)
        Task Update_AddCategoryAsync(int id = 0, string name = "", string urlSlug = "", string description = "", bool showOnMenu = false, CancellationToken cancellation = default);
        // Xóa một chuyên mục theo mã số cho trước
        Task Delete_CategoryAsync(int id, CancellationToken cancellationToken = default);
        // Kiểm tra tên định danh (slug) của một chuyên mục đã tồn tại hay chưa
        Task<bool> CheckCategoryExist_Async(string urlSlug, CancellationToken cancellationToken = default);

        // Lấy và phân trang danh sách chuyên mục, kết quả trả về kiểu IPagedList<CategoryItem>
        Task<IPagedList<CategoryItem>> GetPagedCategoriesAsync(IPagingParams pagingParams, CancellationToken cancellation = default);

        public Task<IPagedList<Post>> GetPagedPostAsync(PostQuery condition, int pageNumber = 1, int pageSize = 10, CancellationToken cancellationToken = default);

        Task<Author> GetAuthor_IdAsync(int id, CancellationToken cancellation = default);
        Task<Author> GetAuthor_SlugAsync(string slug, CancellationToken cancellation = default);
        public Task<Post> GetPostByIdAsync(int postId, bool includeDetails = false, CancellationToken cancellationToken = default);

        public Task<Category> CreateOrUpdateCategoryAsync(Category category, CancellationToken cancellationToken = default);
        public Task<Post> CreateOrUpdatePostAsync(
        Post post, IEnumerable<string> tags,
        CancellationToken cancellationToken = default);

        Task<IList<AuthorItem>> GetAuthorAsync(CancellationToken cancellationToken = default);
        public Task<Tag> GetTagAsync(string slug, CancellationToken cancellationToken = default);
        public Task<IList<TagItem>> GetTagsAsync(CancellationToken cancellationToken = default);

        Task<bool> DeletePostAsync(int id, CancellationToken cancellationToken = default);
        Task<bool> TogglePublishedFlagAsync(
            int postId, CancellationToken cancellationToken = default);

        Task<IList<Post>> GetPostsMonthYearAsync(int month, int year, CancellationToken cancellationToken = default);

        Task<IList<Post>> GetRandomPostsAsync(int number, CancellationToken cancellation = default);

        Task<IList<AuthorItem>> GetPopularAuthorsAsync(int count, CancellationToken cancellationToken = default);

        Task<int> CountPostByDateAsync(int month, int year, CancellationToken cancellationToken = default);

        Task<IList<PostDateItem>> GetNearestMonthsAsync(CancellationToken cancellation = default);

        Task<IList<CategoryItem>> GetCategoriesWithConditionAsync(CategoryQuery condition, CancellationToken cancellationToken = default);

        Task<bool> ToggleShowOnMenuFlagAsync(
           int categoryId, CancellationToken cancellationToken = default);
        Task<IList<AuthorItem>> GetAuthor_KeywordAsync(AuthorQuery condition, CancellationToken cancellationToken = default);

        Task<bool> DeleteAuthorAsync(int id, CancellationToken cancellationToken = default);

        Task<IList<TagItem>> GetTags_KeywordAsync(TagQuery condition,  CancellationToken cancellationToken = default);
    }

}
