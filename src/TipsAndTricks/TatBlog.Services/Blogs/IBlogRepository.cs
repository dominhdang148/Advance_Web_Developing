using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TatBlog.Core.Contracts;
using TatBlog.Core.DTO;
using TatBlog.Core.Entities;

namespace TatBlog.Services.Blogs
{
    public interface IBlogRepository
    {
        // Tìm bài viết có tên định dánh là 'slug'
        // và được đăng vào tháng 'month' năm 'year'
        Task<Post> GetPostAsync(
            int year,
            int month,
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
    }
}
