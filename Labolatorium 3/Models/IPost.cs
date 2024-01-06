using Microsoft.AspNetCore.Mvc;

namespace Labolatorium_3.Models
{
    public interface IPost
    {
        int Add(Post post);
        void Delete(int id);
        void Update(Post post);
        List<Post> FindAll();
        Post? FindById(int id);
    }
}
