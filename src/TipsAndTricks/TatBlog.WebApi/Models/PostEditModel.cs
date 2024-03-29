﻿namespace TatBlog.WebApi.Models
{
    public class PostEditModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDecription { get; set; }
        public string Description { get; set; }
        public string Meta { get; set; }
        public string UrlSlug { get; set; }
        public IFormFile ImageFile { get; set; }
        public string ImageUrl { get; set; }
        public bool Published { get; set; }
        public int CategoryId { get; set; }
        public int AuthorId { get; set; }
        public string SelectedTags { get; set; }


        public List<String> GetSelectedTags() => (SelectedTags ?? "").Split(new[] { ',', ';', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).ToList();

        public static async ValueTask<PostEditModel> BindAsync(HttpContext context)
        {
            var form = await context.Request.ReadFormAsync();
            return new PostEditModel()
            {
                ImageFile = form.Files["ImageFile"],
                Id = int.Parse(form["Id"]),
                Title = form["Title"],
                ShortDecription = form["ShortDescription"],
                Description = form["Description"],
                Meta = form["Meta"],
                Published = bool.Parse(form["Published"]),
                CategoryId = int.Parse(form["CategoryId"]),
                AuthorId = int.Parse(form["AuthorId"]),
                SelectedTags = form["SelectedTags"]
            };
        }
    }
}
