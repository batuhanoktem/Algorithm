using Algorithm.Model.Concrete.Base;
using System.ComponentModel.DataAnnotations;

namespace Algorithm.Model.Concrete.Sub
{
    public class Language : BaseModel
    {
        [StringLength(3)]
        public string Code { get; set; }
        [StringLength(200)]
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
