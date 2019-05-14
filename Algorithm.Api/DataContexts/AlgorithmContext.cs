using Algorithm.Model.Concrete.Multiple;
using Algorithm.Model.Concrete.Sub;
using Microsoft.EntityFrameworkCore;

namespace Algorithm.Api.DataContexts
{
    public class AlgorithmContext : DbContext
    {
        public AlgorithmContext(DbContextOptions<AlgorithmContext> options) : base(options)
        {
        }
        //Sub
        public DbSet<User> User { get; set; }
        public DbSet<Blog> Blog { get; set; }
        public DbSet<FeedBack> FeedBack { get; set; }
        public DbSet<Language> Language { get; set; }
        public DbSet<Parameter> Parameter { get; set; }
        public DbSet<Comment> Comment { get; set; }

        //Multiple
        public DbSet<BlogLanguage> BlogLanguage { get; set; }
        public DbSet<BlogParameter> BlogParameter { get; set; }
        public DbSet<BlogUser> BlogUser { get; set; }

    }
}
