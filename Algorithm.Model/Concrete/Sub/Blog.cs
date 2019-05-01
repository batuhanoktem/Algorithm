using Algorithm.Model.Concrete.Base;
using Algorithm.Model.Enum.Blog;
using System.ComponentModel.DataAnnotations;

namespace Algorithm.Model.Concrete.Sub
{
    public class Blog : BaseModel
    {
        [StringLength(200)]
        public string Title { get; set; }
        public string Content { get; set; }
        public User Author { get; set; }
        public long AuthorId { get; set; }
        public int LikeCount { get; set; }
        public decimal AvgPoint { get; set; }
        public Status Status  { get; set; }
        public Visibility Visibility { get; set; }
        public Blog NextBlog { get; set; }
        public long? NextBlogId { get; set; }
        public Blog PreviousBlog { get; set; }
        public long? PreviousBlogId { get; set; }


    }
}
