using Algorithm.Model.Concrete.Sub;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Model.Concrete.Multiple
{
    public class BlogParameter
    {
        //tag and category for now - maybe we can splite
        public Parameter ParameterId { get; set; }
        public Blog BlogId { get; set; }
    }
}
