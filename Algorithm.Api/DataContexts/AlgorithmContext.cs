using Algorithm.Model.Concrete.Sub;
using Microsoft.EntityFrameworkCore;

namespace Algorithm.Api.DataContexts
{
    public class AlgorithmContext : DbContext
    {
        public AlgorithmContext(DbContextOptions<AlgorithmContext> options) : base(options)
        {
        }

        public DbSet<User> User { get; set; }
    }
}
