using Algorithm.Model.Interface;
using System;

namespace Algorithm.Model.Concrete.Base
{
    public class BaseModel:IEntity
    {
        public long Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime ModifiedDate { get; set; } = DateTime.UtcNow;
    }
}
