using Algorithm.Model.Concrete.Base;
using Algorithm.Model.Enum.Parameter;
using System.ComponentModel.DataAnnotations;

namespace Algorithm.Model.Concrete.Sub
{
    public class Parameter : BaseModel
    {
        [StringLength(200)]
        public string Name { get; set; }
        public Content ContentType { get; set; }
    }
}
