using Algorithm.Model.Concrete.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Algorithm.Model.Concrete.Sub
{
    public class FeedBack : BaseModel
    {
        public string Comment { get; set; }
        public int Rate { get; set; }
        [ForeignKey("Blog")]
        public long BlogId { get; set; }
        public string Mail { get; set; } // not required
    }
}
