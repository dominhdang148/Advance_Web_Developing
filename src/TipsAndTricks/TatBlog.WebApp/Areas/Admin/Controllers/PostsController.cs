﻿using FluentValidation;
using FluentValidation.AspNetCore;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualBasic;
using TatBlog.Core.Constants;
using TatBlog.Core.Entities;
using TatBlog.Services.Blogs;
using TatBlog.Services.Media;
using TatBlog.WebApp.Areas.Admin.Models;

namespace TatBlog.WebApp.Areas.Admin.Controllers
{
    public class PostsController : Controller
    {

        private readonly IBlogRepository _blogRepository;
        private readonly IMapper _mapper;
        private readonly IMediaManager _mediaManager;
        private readonly ILogger<PostsController> _logger;

        public PostsController(IBlogRepository blogRepository, IMapper mapper, IMediaManager mediaManager, ILogger<PostsController> logger)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
            _mediaManager = mediaManager;
            _logger = logger;   
        }
        // Phương thức gán giá trị cho các thuộc tính của 1 đối tượng PostFilterModel

        private async Task PopulatedPostFilterModelAsync(PostFilterModel model)
        {
            var authors = await _blogRepository.GetAuthorAsync();
            var categories = await _blogRepository.GetCategoriesAsync();

            model.AuthorList = authors.Select(a => new SelectListItem()
            {
                Text = a.FullName,
                Value = a.Id.ToString()
            });

            model.CategoryLíst = categories.Select(c => new SelectListItem() { Text = c.Name, Value = c.Id.ToString() });
        }

        private async Task PopulatedPostEditModelAsync(PostEditModel model)
        {
            var authors = await _blogRepository.GetAuthorAsync();

            var categories = await _blogRepository.GetCategoriesAsync();

            model.AuthorList = authors.Select(a => new SelectListItem()
            {
                Text = a.FullName,
                Value = a.Id.ToString()
            });
            model.CategoryList = categories.Select(c => new SelectListItem()
            {
                Text = c.Name,
                Value = c.Id.ToString()
            });
        }

        public async Task<IActionResult> Index(PostFilterModel model)
        {
            _logger.LogInformation("Tạo điều kiện truy vấn");
            var postQuery = _mapper.Map<PostQuery>(model);

            _logger.LogInformation("Lấy dan sách bài viết từ CSDL");
            ViewBag.PostsList = await _blogRepository.GetPagedPostAsync(postQuery, 1, 10);
            _logger.LogInformation("Chuẩn bị dữ liệu cho ViewModel");

            await PopulatedPostFilterModelAsync(model);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id = 0)
        {
            var post = id > 0
                ? await _blogRepository.GetPostByIdAsync(id, true)
                : null;

            var model = post == null
                ? new PostEditModel()
                : _mapper.Map<PostEditModel>(post);

            await PopulatedPostEditModelAsync(model);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(IValidator<PostEditModel> postValidator, PostEditModel model)
        {

            var validationResult = await postValidator.ValidateAsync(model);
            if (validationResult.IsValid)
            {
                validationResult.AddToModelState(ModelState);
            }


            if (!ModelState.IsValid)
            {
                await PopulatedPostEditModelAsync(model);
                return View(model);
            }

            var post = model.Id > 0
                ? await _blogRepository.GetPostByIdAsync(model.Id)
                : null;

            if (post == null)
            {
                post = _mapper.Map<Post>(model);

                post.Id = 0;
                post.PostedDate = DateTime.Now;
            }
            else
            {
                _mapper.Map(model, post);

                post.Category = null;
                post.ModifiedDate = DateTime.Now;
            }

            if (model.ImageFile?.Length > 0)
            {
                var newImagePath = await _mediaManager.SaveFileAsync(
                    model.ImageFile.OpenReadStream(),
                    model.ImageFile.FileName,
                    model.ImageFile.ContentType);
                if (!string.IsNullOrWhiteSpace(newImagePath))
                {
                    await _mediaManager.DeleteFileAsync(post.ImageUrl);
                    post.ImageUrl = newImagePath;
                }
            }

            await _blogRepository.CreateOrUpdatePostAsync(post, model.GetSelectedTags());

            return RedirectToAction(nameof(Index));

        }
        [HttpPost]
        public async Task<IActionResult> VerifyPostSlug(int id, string urlSlug)
        {
            var slugExisted = await _blogRepository.IsPostSlugExistedAsync(id, urlSlug);

            return slugExisted ? Json($"Slug '{urlSlug}' đã được sử dụng") : Json(true);
        }
    }
}
