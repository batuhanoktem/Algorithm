using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Algorithm.Api.DataContexts
{
    public class AlgorithmContext : DbContext
    {
        public AlgorithmContext(DbContextOptions<AlgorithmContext> options)
            : base(options)
        {
        }
    }
}
