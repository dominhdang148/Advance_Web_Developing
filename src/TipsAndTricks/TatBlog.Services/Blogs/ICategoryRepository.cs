using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TatBlog.Core.Constants;
using TatBlog.Core.Contracts;
using TatBlog.Core.DTO;
using TatBlog.Core.Entities;

namespace TatBlog.Services.Blogs
{
    public interface ICategoryRepository
    {
        Task<Category> GetCategoryBySlugAsync(
            string slug,
            CancellationToken cancellationToken = default);
        Task<Category> GetCategoryByIdAsync(int id);
        Task<Category> GetCachedCategoryBySlugAsync(string slug);
        Task<Category> GetCachedCategoryByIdAsync(int id);
        Task<IList<CategoryItem>> GetCategoriesAsync(
            CancellationToken cancellationToken = default);
        Task<IPagedList<CategoryItem>> GetPagedCategoriesAsync(
            IPagingParams pagingParams,
            string name = null,
            CancellationToken cancellationToken = default);
        Task<IPagedList<T>> GetPagedCategoriesAsync<T>(
            Func<IQueryable<Category>, IQueryable<T>> mapper,
            IPagingParams pagingParam,
            string name = null,
            CancellationToken cancellationToken = default);
        Task<bool> AddOrUpdateCategoryAsync(
            Category category,
            CancellationToken cancellation = default);
        Task<bool> DeleteCategoryAsync(
            int categoryId,
            CancellationToken cancellation = default);
        Task<bool> IsCategorySlugExitstedAsync(
            int categoryId,
            string slug,
            CancellationToken cancellation = default);
         
        
        
        
        Task<bool> ToggleShowOnMenuFlagAsync(
           int categoryId, CancellationToken cancellationToken = default);
        Task<IList<CategoryItem>> GetCategoriesWithConditionAsync(CategoryQuery condition, CancellationToken cancellationToken = default);

    }
}