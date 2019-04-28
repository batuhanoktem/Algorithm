using Algorithm.Model.Concrete.Base;
using Algorithm.Model.Enum;

namespace Algorithm.Model.Concrete.Sub
{
    public class Blog : BaseModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        //foreign key bağlantısı
        public User AuthorId { get; set; }
        public int LikeCount { get; set; }
        public decimal AvgPoint { get; set; }
        public Status Status  { get; set; }
        public Visibility Visibility { get; set; }
        //foreign 
        public Blog NextBlog { get; set; }
        public Blog PreviousBlog { get; set; }
        
    }
}
