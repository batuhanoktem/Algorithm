using Algorithm.Model.Concrete.Base;

namespace Algorithm.Model.Concrete.Sub
{
    public class FeedBack : BaseModel
    {
        public string Comment { get; set; }
        public int Rate { get; set; }
        public Blog BlogId { get; set; }
        public string Mail { get; set; } // not required
    }
}
