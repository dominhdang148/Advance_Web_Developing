using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TatBlog.WebApp.Areas.Admin.Models
{
    public class AuthorFilterModel
    {
        [DisplayName("Từ khóa")]

        public string Keyword { get; set; }

        
    }
}
