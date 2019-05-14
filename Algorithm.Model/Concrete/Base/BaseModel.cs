using Algorithm.Model.Interface;
using System;
using System.ComponentModel.DataAnnotations;

namespace Algorithm.Model.Concrete.Base
{
    public class BaseModel : IEntity
    {
        [Key]
        public long Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime ModifiedDate { get; set; } = DateTime.UtcNow;
    }
}
