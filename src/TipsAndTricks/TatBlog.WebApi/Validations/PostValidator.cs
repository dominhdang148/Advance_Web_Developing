using FluentValidation;
using TatBlog.WebApi.Models;

namespace TatBlog.WebApi.Validations
{
    public class PostValidator : AbstractValidator<PostEditModel>
    {
        public PostValidator()
        {
            RuleFor(a => a.Title)
                .NotEmpty()
                .WithMessage("Tiêu đề không được để trống")
                .MaximumLength(100)
                .WithMessage("Tiêu đề tối đa 100 ký tự");

        }
    }
}
