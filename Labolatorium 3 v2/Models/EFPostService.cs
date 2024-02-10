using Data;
using Data.Entities;
using Labolatorium_3_v2.Mappres;
using System;

namespace Labolatorium_3_v2.Models
{
    public class EFPostService : IPostService
    {
        private PostDbContext _context;

        public EFPostService(PostDbContext context)
        {
            _context = context;
        }

        public int Add(Post contact)
        {
            var e = _context.Posts.Add(PostMapper.ToEntity(contact));
            _context.SaveChanges();
            return e.Entity.PostId;
        }

 

        public void Delete(int id)
        {
            PostEntity? find = _context.Posts.Find(id);
            if (find != null)
            {
                _context.Posts.Remove(find);
                _context.SaveChanges();
            }
        }

        public List<Post> FindAll()
        {
            return _context.Posts.Select(e => PostMapper.FromEntity(e)).ToList(); ;
        }

        public List<UserEntity> FindAllUsersForVieModel()
        {
            return _context.UsersforPost.ToList();
        }

        public Post? FindById(int id)
        {
            return PostMapper.FromEntity(_context.Posts.Find(id));
        }

        public void Update(Post post)
        {
            _context.Posts.Update(PostMapper.ToEntity(post));
            _context.SaveChanges();
        }

        
    }
}
