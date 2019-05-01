using Algorithm.Model.Concrete.Base;
using System.ComponentModel.DataAnnotations;

namespace Algorithm.Model.Concrete.Sub
{
    public class FeedBack : BaseModel
    {
        public string Comment { get; set; }
        public int Rate { get; set; }
        public Blog Blog { get; set; }
        public long BlogId { get; set; }
        [StringLength(200)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
