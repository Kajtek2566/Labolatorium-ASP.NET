using Data.Entities;

namespace Labolatorium_3_v2.Models
{
    public class MemoryPostService : IPostService
    {
        private Dictionary<int, Post> _posts = new Dictionary<int, Post>();
        private IDateTimeProvider _timeProvider;

        public MemoryPostService(IDateTimeProvider timeProvider)
        {
            _timeProvider = timeProvider;
        }
        public int Add(Post item)
        {
            int id = _posts.Keys.Count != 0 ? _posts.Keys.Max() : 0;
            item.Id = id + 1;
            item.Publication_date = _timeProvider.CurrentTime();
            _posts.Add(item.Id, item);
            return item.Id;
        }

        public void Delete(int id)
        {
            _posts.Remove(id);
        }

        public List<Post> FindAll()
        {
            return _posts.Values.ToList();
        }

        public List<UserEntity> FindAllUsersForVieModel()
        {
            throw new NotImplementedException();
        }

        public Post? FindById(int id)
        {
            return _posts[id];
        }

        public void Update(Post item)
        {
            _posts[item.Id] = item;
        }
    }
}
