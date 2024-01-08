using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.IEnumerableVsIQueryable
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public ApplicationContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DbHelper.ConnectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Bir obyekt əlavə edirik
            modelBuilder.Entity<User>().HasData(new User { Id = 1, Name = "Tom" });
        }
    }
}
