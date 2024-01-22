using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class PostDbContext : DbContext
    {
        public DbSet<PostEntity> Posts { get; set; }
        private string DbPath { get; set; }
        public PostDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "Posts.db");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options) =>
        options.UseSqlite(@"data source=d:\Posts.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PostEntity>().HasData(
                new PostEntity()
                { 
                    PostId = 1, 
                    Content = "Adam&Ewa", 
                    Autor = "Franek", 
                    Publication_date = new DateTime(2000, 10, 10), 
                    Tags = "People", 
                    Comment = "", 
                    Priority = 1 
                },
                new PostEntity()
                {
                    PostId = 2,
                    Content = "Bees",
                    Autor = "Benek",
                    Publication_date = new DateTime(2023, 10, 10),
                    Tags = "Bees,Honey",
                    Comment = "It is realy suprising that bees can fly",
                    Priority = 2
                }


            );
        }
    }
}