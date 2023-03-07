#region First query
//using TatBlog.Data.Contexts;
//using TatBlog.Data.Seeders;

//// Tọa đối tượng DbContẽt để quản lý phên làm việc
//// với CSDL và trạng thái cảu các đối tượng

//var context = new BlogDbContext();

//// Tạo đối tượng khởi tạo dữ liệu mẫu

//var seeder = new DataSeeder(context);

//// Gọi hàm Initialize để nhập dữ liệu mẫu

//seeder.Initialize();

//// Đọc danh sách tác giả từ cơ sở dữ liệu

//var authors = context.Authors.ToList();

//// Xuất danh sách tác giả ra màn hình

//Console.WriteLine("{0,-4}{1,-30}{2,-30}{3,12}", 
//    "ID", "Full Name", "Email", "Joined Date");

//foreach (var auth in authors)
//{
//    Console.WriteLine("{0,-4}{1,-30}{2,-30}{3,12}", 
//        auth.Id, auth.FullName, auth.Email, auth.JoinedDate);
//}
#endregion

#region Second query
//using TatBlog.Data.Contexts;

//// Tạo đối tượng DbContext để quảng lý phiên làm việc với
//// CSDL và trạng thái của các đối tượng
//var context = new BlogDbContext();

//// Đọc danh sách bài viết từ CSDL
//// Lấy kèm tên tác giả và chuyên mục
//var posts = context.Posts
//    .Where(p => p.Published)
//    .OrderBy(p => p.Title)
//    .Select(p => new
//    {
//        Id = p.Id,
//        Title = p.Title,
//        ViewCount = p.ViewCount,
//        PostedDate = p.PostedDate,
//        Author = p.Author.FullName,
//        Category = p.Category.Name
//    }).ToList();

//// Xuất danh sách bài viết ra màn hình
//foreach (var post in posts)
//{
//    Console.WriteLine("ID            : {0}", post.Id);
//    Console.WriteLine("Title         : {0}", post.Title);
//    Console.WriteLine("View          : {0}", post.ViewCount);
//    Console.WriteLine("Date          : {0:MM/dd/yyyy}", post.PostedDate);
//    Console.WriteLine("Author        : {0}", post.Author);
//    Console.WriteLine("Category      : {0}", post.Category);
//    Console.WriteLine("".PadRight(80, '-'));
//}
#endregion

#region Third query

//using TatBlog.Data.Contexts;
//using TatBlog.Services.Blogs;

//// Tạo đối tượng DbContext để quảng lý phiên làm việc với
//// CSDL và trạng thái của các đối tượng
//var context = new BlogDbContext();

//// Tạo đối tượng BlogRepository

//IBlogRepository blogRepo = new BlogRepository(context);

//// Tìm 3 bài viết được xem/đọc nhiều nhất

//var posts = await blogRepo.GetPopularArticleAsync(3);

//// Xuất danh sách bài viết ra màn hình
//foreach (var post in posts)
//{
//    Console.WriteLine("ID            : {0}", post.Id);
//    Console.WriteLine("Title         : {0}", post.Title);
//    Console.WriteLine("View          : {0}", post.ViewCount);
//    Console.WriteLine("Date          : {0:MM/dd/yyyy}", post.PostedDate);
//    Console.WriteLine("Author        : {0}", post.Author);
//    Console.WriteLine("Category      : {0}", post.Category);
//    Console.WriteLine("".PadRight(80, '-'));
//}

#endregion

#region Fourth query

//using TatBlog.Data.Contexts;
//using TatBlog.Services.Blogs;

//// Tạo đối tượng DbContext để quảng lý phiên làm việc với
//// CSDL và trạng thái của các đối tượng
//var context = new BlogDbContext();

//// Tạo đối tượng BlogRepository

//IBlogRepository blogRepo = new BlogRepository(context);

//// Lấy danh sách chuyên mục

//var categories = await blogRepo.GetCategoriesAsync();

//// Xuất  ra màn hình

//Console.WriteLine("{0,-5}{1,-50}{2,10}", "ID", "Name", "Count");

//foreach (var category in categories)
//{
//    Console.WriteLine("{0,-5}{1,-50}{2,10}", category.Id, category.Name, category.PostCount);
//}

#endregion

#region Fifth query

//using TatBlog.Data.Contexts;
//using TatBlog.Services.Blogs;
//using TatBlog.WinApp;

//// Tạo đối tượng DbContext để quảng lý phiên làm việc với
//// CSDL và trạng thái của các đối tượng
//var context = new BlogDbContext();

//// Tạo đối tượng BlogRepository

//IBlogRepository blogRepo = new BlogRepository(context);

//// Tạo đối tượng chưa tham số phân trang

//var pagingParams = new PagingParams
//{
//    PageNumber = 1,               // Lấy kết quả ở trang số 1
//    PageSize = 5,                 // Lấy 5 mẫu tin
//    SortColumn = "Name",          // Sắp xếp theo tên
//    SortOrder = "DESC"            // Theo chiều giảm dần
//};

//// Lấy danh sách từ khóa

//var tagsList=await blogRepo.GetPagedTagsAsync(pagingParams);

//// Xuất  ra màn hình

//Console.WriteLine("{0,-5}{1,-50}{2,10}", "ID", "Name", "Count");

//foreach (var tag in tagsList)
//{
//    Console.WriteLine("{0,-5}{1,-50}{2,10}", tag.Id, tag.Name, tag.PostCount);
//}

#endregion

// ================================= C.  THỰC HÀNH =======================================
using System.Globalization;
using TatBlog.Data.Contexts;
using TatBlog.Data.Seeders;
using TatBlog.Services.Blogs;
using TatBlog.WinApp;

var context = new BlogDbContext();

var blogRepo = new BlogRepository(context);

#region 1. Hãy tạo các lớp và định nghĩa các phương thức cần thiết để truy vấn dữ liệu theo các yêu cầu sau:

#region a. Tìm một thẻ tag theo tên định danh slug



//var tag = await blogRepo.FindTag_SlugAsync("blazor");

//Console.WriteLine("{0, -5} {1, -20} {2, 10}", "ID", "Name", "UrlSlug");
//Console.WriteLine("{0, -5} {1, -20} {2, 10}", tag.Id, tag.Name, tag.UrlSlug);

//Console.ReadKey();



#endregion

#region b. Tạo lớp DTO có tên là TagItem để chứa các thông tin về thẻ va số lượng bài viết chứa thẻ đó
// Đã là ở file TatBlog.Core.DTO.TagItem.cs
#endregion
#region c. Lấy danh sách tất cả các thẻ (Tag) kèm theo số bài viết chứa thẻ đó. Kết quả trả về kiểu IList<TagItem>

//var tags = await blogRepo.GetAllTagsWithPostAsync();

//Console.WriteLine("{0, -5} {1, -50} {2, 10} ", "ID", "Name", "Post count");
//foreach (var tag in tags)
//{

//    Console.WriteLine("{0, -5} {1, -50} {2, 10}", tag.Id, tag.Name, tag.PostCount);
//}



//Console.ReadKey();

#endregion
#region d. Xóa một thẻ theo mã cho trước
//Console.WriteLine("=============================== BEFORE DELETING ===============================");
//var tags = await blogRepo.GetAllTagsWithPostAsync();

//Console.WriteLine("{0, -5} {1, -50} {2, 10} ", "ID", "Name", "Post count");
//foreach (var tag in tags)
//{

//    Console.WriteLine("{0, -5} {1, -50} {2, 10}", tag.Id, tag.Name, tag.PostCount);
//}

//Console.WriteLine("=============================== AFTER DELETING ===============================");

//await blogRepo.DeleteTagByIDAsync(20);
//tags = await blogRepo.GetAllTagsWithPostAsync();

//Console.WriteLine("{0, -5} {1, -50} {2, 10} ", "ID", "Name", "Post count");
//foreach (var tag in tags)
//{

//    Console.WriteLine("{0, -5} {1, -50} {2, 10}", tag.Id, tag.Name, tag.PostCount);
//}
//Console.ReadKey();
#endregion

#region e. Tìm một chuyên mục (Category) theo tên định danh (slug)

//var category = await blogRepo.FindCategory_SlugAsync("mobile");

//Console.WriteLine("{0, -5} {1, -20} {2, 10}", "ID", "Name", "UrlSlug");
//Console.WriteLine("{0, -5} {1, -20} {2, 10}", category.Id, category.Name, category.UrlSlug);

//Console.ReadKey();

#endregion

#region f. Tìm một chuyên mục theo mã số cho trước

//var category = await blogRepo.FindCategory_IdAsync(5);

//Console.WriteLine("{0, -5} {1, -20} {2, 10}", "ID", "Name", "UrlSlug");
//Console.WriteLine("{0, -5} {1, -20} {2, 10}", category.Id, category.Name, category.UrlSlug);

//Console.ReadKey();

#endregion

#region g. Tìm một chuyên mục theo mã số cho trước

//Console.WriteLine("=============================== BEFORE CHANGING ===============================");
//var categories = await blogRepo.GetCategoriesAsync();

//Console.WriteLine("{0, -5} {1, -50} {2, 10} ", "ID", "Name", "URLSlug");
//foreach (var category in categories)
//{

//    Console.WriteLine("{0, -5} {1, -50} {2, 10}", category.Id, category.Name, category.UrlSlug);
//}

//Console.WriteLine("=============================== AFTER CHANGING ===============================");

//await blogRepo.Update_AddCategory(name:"UI/UX",urlSlug:"ui_ux",description:"Design system interface");
//categories = await blogRepo.GetCategoriesAsync();

//Console.WriteLine("{0, -5} {1, -50} {2, 10} ", "ID", "Name", "URLSlug");
//foreach (var category in categories)
//{
//    Console.WriteLine("{0, -5} {1, -50} {2, 10}", category.Id, category.Name, category.UrlSlug);
//}
//Console.ReadKey();

#endregion

#region h. Xóa một chuyên mục tho mã số cho trước

//Console.WriteLine("=============================== BEFORE DELETING ===============================");
//var categories = await blogRepo.GetCategoriesAsync();

//Console.WriteLine("{0, -5} {1, -50} {2, 10} ", "ID", "Name", "UrlSlug");
//foreach (var category in categories)
//{

//    Console.WriteLine("{0, -5} {1, -50} {2, 10}", category.Id, category.Name, category.UrlSlug);
//}

//Console.WriteLine("=============================== AFTER DELETING ===============================");

//await blogRepo.Delete_CategoryAsync(10);
//categories = await blogRepo.GetCategoriesAsync();

//Console.WriteLine("{0, -5} {1, -50} {2, 10} ", "ID", "Name", "UrlSlug");
//foreach (var category in categories)
//{

//    Console.WriteLine("{0, -5} {1, -50} {2, 10}", category.Id, category.Name, category.UrlSlug);
//}
//Console.ReadKey();

#endregion

#region i. Kiểm tra tên định danh (slug) của một chuyên mục đã tồn tại hay chưa
//bool result = await blogRepo.CheckCategoryExist_Async("algorithms");

//Console.WriteLine(result);
//Console.ReadKey();

#endregion
#region j. Lấy và phân trang danh sách chuyên mục, kết quả trả về kiểu IPagedList<CategoryItem>

var pagingParams = new PagingParams
{
    PageNumber = 1,               // Lấy kết quả ở trang số 1
    PageSize = 5,                 // Lấy 5 mẫu tin
    SortColumn = "Name",          // Sắp xếp theo tên
    SortOrder = "DESC"            // Theo chiều giảm dần
};



var categoriesList = await blogRepo.GetPagedCategoriesAsync(pagingParams);



Console.WriteLine("{0,-5}{1,-50}{2,10}", "ID", "Name", "Count");

foreach (var category in categoriesList)
{
    Console.WriteLine("{0,-5}{1,-50}{2,10}", category.Id, category.Name, category.PostCount);
}

Console.ReadKey();

#endregion
#endregion

