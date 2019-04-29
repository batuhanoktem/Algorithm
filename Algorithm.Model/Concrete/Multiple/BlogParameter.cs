using Algorithm.Model.Concrete.Sub;

namespace Algorithm.Model.Concrete.Multiple
{
    public class BlogParameter
    {
        //tag and category for now - maybe we can splite
        public Parameter ParameterId { get; set; }
        public Blog BlogId { get; set; }
    }
}
