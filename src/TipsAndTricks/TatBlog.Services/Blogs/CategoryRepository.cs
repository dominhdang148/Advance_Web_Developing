using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TatBlog.Core.Constants;
using TatBlog.Core.Contracts;
using TatBlog.Core.DTO;
using TatBlog.Core.Entities;
using TatBlog.Data.Contexts;
using TatBlog.Services.Extensions;

namespace TatBlog.Services.Blogs
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly BlogDbContext _context;
        private readonly IMemoryCache _memoryCache;

        public CategoryRepository(BlogDbContext context, IMemoryCache memoryCache)
        {
            _context = context;
            _memoryCache = memoryCache;
        }

        public async Task<bool> AddOrUpdateCategoryAsync(Category category, CancellationToken cancellation = default)
        {
            if (category.Id > 0)
            {
                _context.Categories.Update(category);
                _memoryCache.Remove($"categoty.by-id.{category.Id}");
            }
            else
                _context.Categories.Add(category);
            return await _context.SaveChangesAsync(cancellation) > 0;
        }

        public async Task<bool> DeleteCategoryAsync(int categoryId, CancellationToken cancellation = default)
        {
            return await _context.Categories
                .Where(x => x.Id == categoryId)
                .ExecuteDeleteAsync(cancellation) > 0;
        }

        public async Task<Category> GetCachedCategoryByIdAsync(int id)
        {
            return await _memoryCache.GetOrCreateAsync(
                $"category.by-id.{id}",
                async (entry) =>
                {
                    entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30);
                    return await GetCategoryByIdAsync(id);
                });
        }

        public async Task<Category> GetCachedCategoryBySlugAsync(string slug)
        {
            return await _memoryCache.GetOrCreateAsync(
                 $"category.by-slug.{slug}",
                 async (entry) =>
                 {
                     entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30);
                     return await GetCategoryBySlugAsync(slug);
                 });
        }

        public async Task<IList<CategoryItem>> GetCategoriesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Set<Category>()
                .OrderBy(c => c.Name)
                .Select(x => new CategoryItem()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    UrlSlug = x.UrlSlug,
                    ShowOnMenu = x.ShowOnMenu,
                    PostCount = x.Posts.Count(p => p.Published)
                })
                .ToListAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await _context.Set<Category>().FindAsync(id);
        }

        public async Task<Category> GetCategoryBySlugAsync(string slug, CancellationToken cancellationToken = default)
        {
            return await _context.Set<Category>()
                .FirstOrDefaultAsync(c => c.UrlSlug == slug, cancellationToken);
        }

        public async Task<IPagedList<CategoryItem>> GetPagedCategoriesAsync(
            IPagingParams pagingParams, 
            string name = null, 
            CancellationToken cancellationToken = default)
        {
            return await _context.Set<Category>()
                .AsNoTracking()
                .WhereIf(!string.IsNullOrWhiteSpace(name), x => x.Name.Contains(name))
                .Select(c => new CategoryItem()
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description,
                    UrlSlug = c.UrlSlug,
                    ShowOnMenu = c.ShowOnMenu,
                    PostCount = c.Posts.Count(p => p.Published)
                }).ToPagedListAsync(pagingParams, cancellationToken);
        }

        public async Task<IPagedList<T>> GetPagedCategoriesAsync<T>(
           Func<IQueryable<Category>, IQueryable<T>> mapper,
           IPagingParams pagingParams,
           string name = null,
           CancellationToken cancellationToken = default)
        {
            var categoryQuery = _context.Set<Category>().AsNoTracking();

            if (!string.IsNullOrWhiteSpace(name))
            {
                categoryQuery = categoryQuery.Where(x => x.Name.Contains(name));
            }

            return await mapper(categoryQuery).ToPagedListAsync(pagingParams, cancellationToken);
        }

        public async Task<bool> IsCategorySlugExitstedAsync(int categoryId, string slug, CancellationToken cancellation = default)
        {
            return await _context.Categories.AnyAsync(x => x.Id != categoryId && x.UrlSlug == slug, cancellation);
        }




        public async Task<bool> ToggleShowOnMenuFlagAsync(int categoryId, CancellationToken cancellationToken = default)
        {
            var category = await _context.Set<Category>().FindAsync(categoryId);

            if (category is null) return false;

            category.ShowOnMenu = !category.ShowOnMenu;
            await _context.SaveChangesAsync(cancellationToken);

            return category.ShowOnMenu;
        }
        public IQueryable<Category> CategoryFilter(CategoryQuery condition)
        {
            return _context.Set<Category>()
                .WhereIf(!String.IsNullOrWhiteSpace(condition.Keyword), c => c.Name.ToLower().Contains(condition.Keyword.ToLower()))
                .WhereIf(condition.ShowOnMenu != 0, c => c.ShowOnMenu == (condition.ShowOnMenu == 1 ? true : false));
        }


        public async Task<IList<CategoryItem>> GetCategoriesWithConditionAsync(CategoryQuery condition, CancellationToken cancellationToken = default)
        {
            return await CategoryFilter(condition)
               .OrderBy(c => c.Name)
               .Select(x => new CategoryItem()
               {
                   Id = x.Id,
                   Name = x.Name,
                   Description = x.Description,
                   ShowOnMenu = x.ShowOnMenu,
                   UrlSlug = x.UrlSlug,
                   PostCount = x.Posts.Count(p => p.Published),
               })
               .ToListAsync(cancellationToken);
        }
    }
}