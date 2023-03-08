using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TatBlog.Core.Constants;
using TatBlog.Core.Contracts;
using TatBlog.Core.DTO;
using TatBlog.Core.Entities;
using TatBlog.Data.Contexts;
using TatBlog.Services.Extensions;

namespace TatBlog.Services.Blogs
{
    public class BlogRepository : IBlogRepository
    {
        private readonly BlogDbContext _context;

        public async Task<IList<Post>> GetPopularArticleAsync(int numPosts, CancellationToken cancellation = default)
        {
            return await _context.Set<Post>()
                .Include(x => x.Author)
                .Include(x => x.Category)
                .OrderByDescending(p => p.ViewCount)
                .Take(numPosts)
                .ToListAsync(cancellation);
        }

        public async Task<Post> GetPostAsync(int year, int month, string slug, CancellationToken cancellationToken = default)
        {
            IQueryable<Post> postsQuery = _context.Set<Post>().Include(x => x.Category).Include(x => x.Author);

            if (year > 0)
            {
                postsQuery = postsQuery.Where(x => x.PostedDate.Year == year);
            }
            if (month > 0)
            {
                postsQuery = postsQuery.Where(x => x.PostedDate.Month == month);
            }
            if (!string.IsNullOrWhiteSpace(slug))
            {
                postsQuery = postsQuery.Where(x => x.UrlSlug == slug);
            }

            return await postsQuery.FirstOrDefaultAsync(cancellationToken);
        }

        public async Task IncreaseViewCountAsync(int postId, CancellationToken cancellationToken = default)
        {
            await _context.Set<Post>()
                .Where(x => x.Id == postId)
                .ExecuteUpdateAsync(p =>
                p.SetProperty(x => x.ViewCount, x => x.ViewCount + 1),
                cancellationToken);
        }

        public async Task<bool> IsPostSlugExistedAsync(int postID, string slug, CancellationToken cancellationToken = default)
        {
            return await _context.Set<Post>()
                .AnyAsync(x => x.Id != postID && x.UrlSlug == slug, cancellationToken);
        }

        public async Task<IList<CategoryItem>> GetCategoriesAsync(bool showOnMenu = false, CancellationToken cancellationToken = default)
        {
            IQueryable<Category> categories = _context.Set<Category>();

            if (showOnMenu)
            {
                categories = categories.Where(x => x.ShowOnMenu);
            }

            return await categories.OrderBy(x => x.Name).Select(x => new CategoryItem()
            {
                Id = x.Id,
                Name = x.Name,
                UrlSlug = x.UrlSlug,
                Description = x.Description,
                ShowOnMenu = x.ShowOnMenu,
                PostCount = x.Posts.Count(p => p.Published)
            }).ToListAsync(cancellationToken);
        }

        public async Task<IPagedList<TagItem>> GetPagedTagsAsync(IPagingParams pagingParams, CancellationToken cancellationToken)
        {
            var tagQuery = _context.Set<Tag>()
                .Select(x => new TagItem()
                {
                    Id = x.Id,
                    Name = x.Name,
                    UrlSlug = x.UrlSlug,
                    Description = x.Description,
                    PostCount = x.Posts.Count(p => p.Published)
                });
            return await tagQuery.ToPagedListAsync(pagingParams, cancellationToken);
        }

        public async Task<Tag> FindTag_SlugAsync(string slug, CancellationToken cancellationToken = default)
        {
            IQueryable<Tag> tagsQuery = _context.Set<Tag>()
                .Where(t => t.UrlSlug == slug);
            return await tagsQuery.FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<IList<TagItem>> GetAllTagsWithPostAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Set<Tag>().Select(x => new TagItem()
            {
                Id = x.Id,
                Name = x.Name,
                UrlSlug = x.UrlSlug,
                Description = x.Description,
                PostCount = x.Posts.Count(p => p.Published)
            }).ToListAsync(cancellationToken);
        }

        public async Task DeleteTagByIDAsync(int id, CancellationToken cancellationToken = default)
        {
            var tag = new Tag()
            {
                Id = id,
            };
            _context.Remove(tag);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<Category> FindCategory_SlugAsync(string slug, CancellationToken cancellation = default)
        {
            IQueryable<Category> categories = _context.Set<Category>();
            if (!string.IsNullOrWhiteSpace(slug))
            {
                categories = categories.Where(t => t.UrlSlug == slug);
            }
            return await categories.FirstOrDefaultAsync(cancellation);
        }

        public async Task<Category> FindCategory_IdAsync(int id, CancellationToken cancellationToken = default)
        {
            IQueryable<Category> categories = _context.Set<Category>();
            if (id != 0)
            {
                categories = categories.Where(t => t.Id == id);
            }
            return await categories.FirstOrDefaultAsync(cancellationToken);
        }

        public async Task Update_AddCategoryAsync(int id = 0, string name = "", string urlSlug = "", string description = "", bool showOnMenu = false, CancellationToken cancellation = default)
        {
            var category = _context.Set<Category>().FirstOrDefault(c => c.Id == id);
            if (category != null)
            {
                if (!string.IsNullOrWhiteSpace(name))
                {
                    category.Name = name;
                }
                if (!string.IsNullOrWhiteSpace(urlSlug))
                {
                    category.UrlSlug = urlSlug;
                }
                if (!string.IsNullOrWhiteSpace(description))
                {
                    category.Description = description;
                }
                category.ShowOnMenu = showOnMenu;
            }

            else
            {
                if (!(string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(urlSlug)))
                {
                    _context.Add(new Category()
                    {
                        Name = name,
                        UrlSlug = urlSlug,
                        Description = description,
                        ShowOnMenu = showOnMenu
                    });
                }

            }

            await _context.SaveChangesAsync(cancellation);
        }

        public async Task Delete_CategoryAsync(int id, CancellationToken cancellationToken = default)
        {
            var category = new Category()
            {
                Id = id
            };
            _context.Remove(category);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<bool> CheckCategoryExist_Async(string urlSlug, CancellationToken cancellationToken = default)
        {
            return await _context.Set<Category>()
                .AnyAsync(x => x.UrlSlug == urlSlug, cancellationToken);
        }

        public async Task<IPagedList<CategoryItem>> GetPagedCategoriesAsync(IPagingParams pagingParams, CancellationToken cancellation = default)
        {
            var categoryQuery = _context.Set<Category>()
                .Select(x => new CategoryItem()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    ShowOnMenu = x.ShowOnMenu,
                    UrlSlug = x.UrlSlug,
                    PostCount = x.Posts.Count(p => p.Published),
                });
            return await categoryQuery.ToPagedListAsync(pagingParams, cancellation);
        }
        public IQueryable<Post> FilterPost(PostQuery condition)
        {
            return _context.Set<Post>()
                .Include(c => c.Category)
                .Include(t => t.Tags)
                .Include(a => a.Author)
                .WhereIf(condition.AuthorId > 0, p => p.AuthorId == condition.AuthorId)
                .WhereIf(!string.IsNullOrWhiteSpace(condition.AuthorSlug), p => p.UrlSlug == condition.AuthorSlug)
                .WhereIf(condition.PostId > 0, p => p.Id == condition.PostId)
                .WhereIf(condition.CategoryId > 0, p => p.CategoryId == condition.CategoryId)
                .WhereIf(!string.IsNullOrWhiteSpace(condition.CategorySlug), p => p.Category.UrlSlug == condition.CategorySlug)
                .WhereIf(condition.PostedYear > 0, p => p.PostedDate.Year == condition.PostedYear)
                .WhereIf(condition.PostedMonth > 0, p => p.PostedDate.Month == condition.PostedMonth)
                .WhereIf(condition.TagId > 0, p => p.Tags.Any(x => x.Id == condition.TagId))
                .WhereIf(!string.IsNullOrWhiteSpace(condition.TagSlug), p => p.Tags.Any(x => x.UrlSlug == condition.TagSlug))
                .WhereIf(condition.PublishedOnly != null, p => p.Published == condition.PublishedOnly);
        }


        public async Task<IPagedList<Post>> GetPagedPostAsync(PostQuery condition, int pageNumber = 1, int pageSize = 10, CancellationToken cancellationToken = default)
        {
            return await FilterPost(condition)
                .ToPagedListAsync(
                    pageNumber, pageSize,
                    nameof(Post.PostedDate), "DESC",
                    cancellationToken);
        }

        public BlogRepository(BlogDbContext context)
        {
            _context = context;
        }
    }
}
