﻿namespace TatBlog.WebApi.Models
{
    public class PostDetail
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string Meta { get; set; }
        public string UrlSlug { get; set; }
        public string ImageUlr { get; set; }
        public string ViewCount { get; set; }
        public DateTime PostedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool Published { get; set; }
        public CategoryDto Category { get; set; }
        public AuthorDto Author { get; set; }
        public IList<TagDto> Tags { get; set; }

    }
}
