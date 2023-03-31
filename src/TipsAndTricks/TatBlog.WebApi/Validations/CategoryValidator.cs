﻿using FluentValidation;
using TatBlog.WebApi.Models;

namespace TatBlog.WebApi.Validations
{
    public class CategoryValidator : AbstractValidator<CategoryEditModel>
    {
        public CategoryValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .WithMessage("Tên chuyên mục không được để trống")
                .MaximumLength(100)
                .WithMessage("Tên chuyên mục tối đa 100 ký tự");

            RuleFor(c => c.UrlSlug)
                .NotEmpty()
                .WithMessage("UrlSlug không được để trống")
                .MaximumLength(100)
                .WithMessage("UrlSlug tối đa 100 ký tự");

            RuleFor(c => c.Description)
                 .MaximumLength(500)
                 .WithMessage("Mô tả chuyên mục tối đa 500 ký tự");
        }
    }
}
