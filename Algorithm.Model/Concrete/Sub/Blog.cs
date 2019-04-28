using Algorithm.Model.Concrete.Base;
using Algorithm.Model.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace Algorithm.Model.Concrete.Sub
{
    public class Blog : BaseModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        [ForeignKey("User")]
        public User Author { get; set; }
        public long AuthorId { get; set; }
        public int LikeCount { get; set; }
        public decimal AvgPoint { get; set; }
        public Status Status  { get; set; }
        public Visibility Visibility { get; set; }
        [ForeignKey("User")]
        public Blog NextBlog { get; set; }
        public long NextBlogId { get; set; }
        [ForeignKey("User")]
        public Blog PreviousBlog { get; set; }
        public long PreviousBlogId { get; set; }


    }
}
