using Algorithm.Model.Concrete.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Algorithm.Model.Concrete.Sub
{
    public class Comment : BaseModel
    {
        public string Content { get; set; }
        public Comment ParentComment { get; set; }
        [ForeignKey("Blog")]
        public long BlogId { get; set; }
        [ForeignKey("User")]
        public User User { get; set; }
        public long UserId { get; set; }
    }
}
