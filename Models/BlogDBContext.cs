using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;

namespace Projects.Models
{
    public class BlogDBContext: DbContext
    {
        public BlogDBContext(DbContextOptions<BlogDBContext> options): base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // optionsBuilder.UseSqlite($"Data Source=BlogDB.db");
            optionsBuilder.UseNpgsql($"Host=ec2-107-22-211-248.compute-1.amazonaws.com;Database=d7np0icrgf0e5p;Username=qbnruynckzauih;Password=54f888eb568392e1802867ddc0a25cf70927048cb05e97fbcb106cab8f3d8d1f");
        }

        public DbSet<BlogsEntityModel> Blogs {get; set;}

    }
}
