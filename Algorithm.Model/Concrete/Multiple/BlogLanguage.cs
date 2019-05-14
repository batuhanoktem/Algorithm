using Algorithm.Model.Concrete.Base;
using Algorithm.Model.Concrete.Sub;

namespace Algorithm.Model.Concrete.Multiple
{
    public class BlogLanguage: BaseModel
    {
        public long BlogId { get; set; }
        public long LanguageId { get; set; }
    }
}
