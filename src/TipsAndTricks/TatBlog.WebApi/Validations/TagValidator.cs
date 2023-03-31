using FluentValidation;
using FluentValidation.AspNetCore;
using TatBlog.WebApi.Models;

namespace TatBlog.WebApi.Validations
{
    public class TagValidator : AbstractValidator<TagEditModel>
    {
        public TagValidator()
        {
            RuleFor(t => t.Name)
                   .NotEmpty()
                   .WithMessage("Tên thẻ không được để trống")
                   .MaximumLength(100)
                   .WithMessage("Tên thẻ không vượt quá 100 ký tự");

            RuleFor(t => t.Description)
                .MaximumLength(500)
                .WithMessage("Mô tả không vượt quá 500 ký tự");

            RuleFor(t => t.UrlSlug)
                .NotEmpty()
                .WithMessage("UrlSlug không được để trống")
                .MaximumLength(100)
                .WithMessage("UrlSlug không vượt quá 100 ký tự");
        }
    }
}
