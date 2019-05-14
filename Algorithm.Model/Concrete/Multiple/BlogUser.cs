using Algorithm.Model.Concrete.Base;
using Algorithm.Model.Concrete.Sub;
using Algorithm.Model.Enum.BlogUser;

namespace Algorithm.Model.Concrete.Multiple
{
    public class BlogUser : BaseModel
    {
        public long BlogId { get; set; }
        public long UserId { get; set; }
        public Content ContentType { get; set; }
    }
}
