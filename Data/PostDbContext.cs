using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class PostDbContext : DbContext
    {
        public DbSet<PostEntity> Posts { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        private string DbPath { get; set; }
        public PostDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "Posts.db");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options) =>
        options.UseSqlite($"data source={DbPath}");



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PostEntity>()
            .HasOne(e => e.User)
            .WithMany(o => o.Posts)
            .HasForeignKey(e => e.UserId);



            modelBuilder.Entity<UserEntity>().HasData(
                new UserEntity()
                {
                    Id= 1,
                    Login = "KarolAdmin",
                    Email = "admin@wp.pl",
                    PhoneNumber = "+48123456789",
                },

                new UserEntity()
                {
                    Id= 2,
                    Login = "France",
                    Email = "Franciszek@wp.pl",
                    PhoneNumber = "+48999456789",
                }) ; 

            modelBuilder.Entity<PostEntity>().HasData(
                new PostEntity()
                { 
                    PostId = 1, 
                    Content = "Adam&Ewa", 
                    Autor = "Franek", 
                    Publication_date = new DateTime(2000, 10, 10), 
                    Tags = "People", 
                    Comment = "", 
                    Priority = 1 ,
                    UserId = 1,
                },
                new PostEntity()
                {
                    PostId = 2,
                    Content = "Bees",
                    Autor = "Benek",
                    Publication_date = new DateTime(2023, 10, 10),
                    Tags = "Bees,Honey",
                    Comment = "It is realy suprising that bees can fly",
                    Priority = 2,
                    UserId = 2,
                }


            );
        }
    }
}