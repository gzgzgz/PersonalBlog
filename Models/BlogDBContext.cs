using Microsoft.EntityFrameworkCore;

namespace Projects.Models
{
    public class BlogDBContext: DbContext
    {
        public BlogDBContext(DbContextOptions<BlogDBContext> options): base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source=/app/BlogDB.db");
        }

        public DbSet<BlogsEntityModel> Blogs {get; set;}

    }
}