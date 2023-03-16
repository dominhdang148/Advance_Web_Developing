using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.Drawing.Text;
using System.Globalization;
using TatBlog.Services.Blogs;

namespace TatBlog.WebApp.Areas.Admin.Models
{
    public class PostFilterModel
    {
        [DisplayName("Từ khóa")]
        public string Keyword { get; set; }

        [DisplayName("Tác giả")]
        public int AuthorID { get; set; }

        [DisplayName("Chủ đề")]
        public int CategoryID { get; set; }

        [DisplayName("Năm")]
        public int Year { get; set; }

        [DisplayName("Tháng")]
        public int Month { get; set; }


        public IEnumerable<SelectListItem> AuthorList { get; set; }
        public IEnumerable<SelectListItem> CategoryLíst { get; set; }
        public IEnumerable<SelectListItem> MonthList
        {
            get; set;
        }

        public PostFilterModel()
        {
            MonthList = Enumerable.Range(1, 12).Select(m => new SelectListItem()
            {
                Value = m.ToString(),
                Text = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(m)
            }).ToList();
        }
    }
}
