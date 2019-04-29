using Algorithm.Model.Concrete.Base;

namespace Algorithm.Model.Concrete.Sub
{
    public class Comment : BaseModel
    {
        public string Content { get; set; }
        public Comment ParentComment { get; set; }
        public long ParentCommentId { get; set; }
        public Blog Blog { get; set; }
        public long BlogId { get; set; }
        public User User { get; set; }
        public long UserId { get; set; }
    }
}
