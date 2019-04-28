using Algorithm.Model.Concrete.Base;

namespace Algorithm.Model.Concrete.Sub
{
    public class Comment : BaseModel
    {
        public string Content { get; set; }
        public Comment ParentComment { get; set; }
        public Blog BlogId { get; set; }
        public User UserId { get; set; }
    }
}
