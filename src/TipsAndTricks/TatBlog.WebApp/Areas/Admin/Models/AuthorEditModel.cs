using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TatBlog.WebApp.Areas.Admin.Models
{
    public class AuthorEditModel
    {
        public int Id { get; set; }

        [DisplayName("Họ tên")]
        //[Required(ErrorMessage = "Tiêu đề không được để trống")]
        //[MaxLength(500, ErrorMessage = "Tiêu đề tối đa 500 ký tự")]

        public string FullName { get; set; }

        [DisplayName("Slug")]
        [Remote("VerifyPostSlug", "Posts", "Admin", HttpMethod = "POST", AdditionalFields = "Id")]
        //[Required(ErrorMessage = "URL slug không được để trống")]
        //[MaxLength(200, ErrorMessage = "URL slug tối đa 200 ký tự")]

        public string UrlSlug { get; set; }

        [DisplayName("Chọn hình ảnh")]

        public IFormFile ImageFile { get; set; }

        [DisplayName("Hình hiện tại")]

        public string ImageUrl { get; set; }

        [DisplayName("Email")]
        //[Required(ErrorMessage = "Tiêu đề không được để trống")]
        //[MaxLength(500, ErrorMessage = "Tiêu đề tối đa 500 ký tự")]

        public string Email { get; set; }

        [DisplayName("Ghi chú")]
        //[Required(ErrorMessage = "Tiêu đề không được để trống")]
        //[MaxLength(500, ErrorMessage = "Tiêu đề tối đa 500 ký tự")]

        public string Notes { get; set; }
    }
}
