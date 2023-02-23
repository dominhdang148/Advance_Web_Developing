using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TatBlog.Core.Contracts;

namespace TatBlog.Core.Entities
{
    // Biểu diễn một từ khóa trong bài viết
    public class Tag: IEntity
    {
        // Mã từ khóa
        public int Id { get; set; }

        // Nội dụng từ khóa
        public string Name { get; set; }    

        // Tên định danh để tạo URL
        public string UrlSlug { get; set; }

        // Mô tả thêm về từ khóa
        public string Description { get; set; }

        // Danh sách bài viết có chứa từ khóa
        public IList<Post> Posts { get; set; }
    }
}
