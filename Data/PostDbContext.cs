using Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class PostDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<PostEntity> Posts { get; set; }
        public DbSet<UserEntity> UsersforPost { get; set; }
        private string DbPath { get; set; }
        public PostDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "Posts.db");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.UseSqlite($"data source={DbPath}");



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            string ADMIN_ID = Guid.NewGuid().ToString();
            string ROLE_ID = Guid.NewGuid().ToString();

            string USER_ID = Guid.NewGuid().ToString();
            string ROLE_USER_ID = Guid.NewGuid().ToString();

            PasswordHasher<IdentityUser> ph = new PasswordHasher<IdentityUser>();


            modelBuilder.Entity<IdentityRole>().HasData(
            new IdentityRole
            {
                Name = "admin",
                NormalizedName = "ADMIN",
                Id = ROLE_ID,
                ConcurrencyStamp = ROLE_ID
            },
            new IdentityRole
            {
                Name = "user",
                NormalizedName = "USER",
                Id = ROLE_USER_ID,
                ConcurrencyStamp = ROLE_USER_ID
            });

            var admin = new IdentityUser
            {
                Id = ADMIN_ID,
                Email = "Kajetan.stach@wsei.edu.pl",
                EmailConfirmed = true,
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                NormalizedEmail = "KAJETAN.STACH@WSEI.EDU.PL"
            };

            admin.PasswordHash = ph.HashPassword(admin, "1234abcd!@#$ABCD");

            var user = new IdentityUser
            {
                Id = USER_ID,
                Email = "Franek@wsei.edu.pl",
                EmailConfirmed = true,
                UserName = "Franek",
                NormalizedUserName = "FRANEK",
                NormalizedEmail = "FRANEK@WSEI.EDU.PL"
            };

            user.PasswordHash = ph.HashPassword(user, "Abc123!@");

            modelBuilder.Entity<IdentityUser>().HasData(admin, user);

            modelBuilder.Entity<IdentityUserRole<string>>()
                .HasData(
                new IdentityUserRole<string>
                {
                    RoleId = ROLE_ID,
                    UserId = ADMIN_ID
                },
                new IdentityUserRole<string>
                {
                    RoleId = ROLE_USER_ID,
                    UserId = USER_ID
                });



            modelBuilder.Entity<PostEntity>()
            .HasOne(e => e.User)
            .WithMany(o => o.Posts)
            .HasForeignKey(e => e.UserId);



            modelBuilder.Entity<UserEntity>().HasData(
                new UserEntity()
                {
                    Id = 1,
                    Login = "KarolAdmin",
                    Email = "admin@wp.pl",
                    PhoneNumber = "+48123456789",
                },

                new UserEntity()
                {
                    Id = 2,
                    Login = "France",
                    Email = "Franciszek@wp.pl",
                    PhoneNumber = "+48999456789",
                });

            modelBuilder.Entity<PostEntity>().HasData(
                new PostEntity()
                {
                    PostId = 1,
                    Content = "Adam&Ewa",
                    Autor = "Franek",
                    Publication_date = new DateTime(2000, 10, 10),
                    Tags = "People",
                    Comment = "",
                    Priority = 1,
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