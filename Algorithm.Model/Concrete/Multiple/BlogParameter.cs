using Algorithm.Model.Concrete.Base;
using Algorithm.Model.Concrete.Sub;

namespace Algorithm.Model.Concrete.Multiple
{
    public class BlogParameter : BaseModel
    {
        //tag and category for now - maybe we can splite
        public long ParameterId { get; set; }
        public long BlogId { get; set; }
    }
}
