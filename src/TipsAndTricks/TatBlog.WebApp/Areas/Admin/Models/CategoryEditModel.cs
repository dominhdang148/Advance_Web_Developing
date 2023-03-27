using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace TatBlog.WebApp.Areas.Admin.Models
{
    public class CategoryEditModel
    {
        public int Id { get; set; } 

        [DisplayName("Tên chủ đề")]
        public string Name { get; set; }
        [DisplayName("Nội dung")]
        public string Description { get; set; }
        [DisplayName("Tên định danh")]
        [Remote("VerifyPostSlug", "Posts", "Admin", HttpMethod = "POST", AdditionalFields = "Id")]
        public string  UrlSlug{ get; set; }

        [DisplayName("Xem trên menu")]

        public bool ShowOnMenu { get; set; }
    }
}
