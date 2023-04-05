using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using SlugGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TatBlog.Core.Constants;
using TatBlog.Core.Contracts;
using TatBlog.Core.DTO;
using TatBlog.Core.Entities;
using TatBlog.Data.Contexts;
using TatBlog.Services.Extensions;

namespace TatBlog.Services.Blogs
{
    public class TagRepository : ITagRepository
    {
        private readonly BlogDbContext _context;
        private readonly IMemoryCache _memoryCache;

        public TagRepository(BlogDbContext context, IMemoryCache memoryCache)
        {
            _context = context;
            _memoryCache = memoryCache;
        }

        public async Task<bool> AddOrUpdateTagAsync(Tag tag, CancellationToken cancellation = default)
        {
            if (tag.Id > 0)
            {
                _context.Tags.Update(tag);
                _memoryCache.Remove($"tag.by-id.{tag.Id}");
            }
            else _context.Tags.Add(tag);
            return await _context.SaveChangesAsync(cancellation) > 0;
        }

        public async Task<bool> DeleteTagAsync(int tagId, CancellationToken cancellation = default)
        {
            return await _context.Tags
                 .Where(x => x.Id == tagId)
                 .ExecuteDeleteAsync(cancellation) > 0;
        }

        public async Task<Tag> GetCacheCategoryBySlugAsync(string slug)
        {
            return await _memoryCache.GetOrCreateAsync(
                $"tag.by-slug.{slug}",
                async (entry) =>
                {
                    entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30);
                    return await GetTagBySlugAsync(slug);
                });
        }

        public async Task<Tag> GetCachedCategoryByIdAsync(int id)
        {
            return await _memoryCache.GetOrCreateAsync(
                $"tag.by-id.{id}",
                async (entry) =>
                {
                    entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30);
                    return await GetTagByIdAsync(id);
                });
        }

        public async Task<IPagedList<TagItem>> GetPagedTagsAsync(IPagingParams pagingParams, string name = null, CancellationToken cancellation = default)
        {
            return await _context.Set<Tag>()
                .AsNoTracking()
                .WhereIf(!string.IsNullOrWhiteSpace(name), x => x.Name.Contains(name))
                .Select(t => new TagItem()
                {
                    Id = t.Id,
                    Name = t.Name,
                    Description = t.Description,
                    UrlSlug = t.UrlSlug,
                    PostCount = t.Posts.Count(p => p.Published),
                }).ToPagedListAsync(pagingParams, cancellation);
        }

        public async Task<IPagedList<T>> GetPagedTagsAsync<T>(Func<IQueryable<Tag>, IQueryable<T>> mapper, IPagingParams pagingParams, string name = null, CancellationToken cancellation = default)
        {
            var tagQuery = _context.Set<Tag>().AsNoTracking();
            if (!string.IsNullOrWhiteSpace(name))
            {
                tagQuery = tagQuery.Where(x => x.Name.Contains(name));
            }
            return await mapper(tagQuery).ToPagedListAsync<T>(pagingParams, cancellation);
        }

        public async Task<Tag> GetTagByIdAsync(int id)
        {
            return await _context.Set<Tag>().FindAsync(id);
        }

        public async Task<Tag> GetTagBySlugAsync(string slug, CancellationToken cancellation = default)
        {
            return await _context.Set<Tag>()
                .FirstOrDefaultAsync(t => t.UrlSlug == slug, cancellation);
        }

        public async Task<IList<TagItem>> GetTagsAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Set<Tag>()
                 .OrderBy(t => t.Name)
                 .Select(t => new TagItem()
                 {
                     Id=t.Id,
                     Name=t.Name,
                     Description=t.Description,
                     UrlSlug=t.UrlSlug,
                     PostCount = t.Posts.Count(p=>p.Published),
                 }).ToListAsync();
        }

        public async Task<bool> IsTagSlugExistedAsync(int tagId, string slug, CancellationToken cancellation = default)
        {
            return await _context.Tags.AnyAsync(x => x.Id != tagId && x.UrlSlug == slug, cancellation);
        }


        //======================================================================

        public async Task<IList<TagItem>> GetTags_KeywordAsync(TagQuery condition, CancellationToken cancellationToken = default)
        {
            return await _context.Set<Tag>()
                 .WhereIf(!String.IsNullOrWhiteSpace(condition.Keyword), t => t.Name.ToLower().Contains(condition.Keyword.ToLower()))
                 .OrderBy(t => t.Name)
                 .Select(x => new TagItem()
                 {
                     Id = x.Id,
                     Name = x.Name,
                     Description = x.Description,
                     UrlSlug = x.UrlSlug,
                     PostCount = x.Posts.Count(p => p.Published)
                 })
                 .ToListAsync(cancellationToken);
        }
    }
}
