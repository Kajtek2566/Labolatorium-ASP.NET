using Microsoft.AspNetCore.Mvc;

namespace Labolatorium_3.Models
{
    public class MemoryPostService : IPost
    {
        private Dictionary<int, Post> _posts = new Dictionary<int, Post>();
        private IDateTimeProvider _timeProvider;

        public MemoryPostService(IDateTimeProvider timeProvider)
        {
            _timeProvider = timeProvider;
        }

        public int Add(Post post)
        {
            int id = _posts.Keys.Count != 0 ? _posts.Keys.Max() : 0;
            post.Id = id + 1;
            post.Created = _timeProvider.CurrentTime();
            _posts.Add(post.Id, post);
            return post.Id;
        }

        public void Delete(int id)
        {
            _posts.Remove(id);
        }

        public List<Post> FindAll()
        {
            return _posts.Values.ToList();
        }

        public Post? FindById(int id)
        {
            return _posts[id];
        }

        public void Update(Post post)
        {
            _posts[post.Id] = post;
        }
    }
}
