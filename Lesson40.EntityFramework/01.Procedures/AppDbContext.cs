using Microsoft.EntityFrameworkCore;
using _05.StoredProcedures.Models;

namespace _05.StoredProcedures
{
    class AppDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }

        public AppDbContext() : base() { }

        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(DbHelper.ConnectionString);
            }
        }
    }
}
