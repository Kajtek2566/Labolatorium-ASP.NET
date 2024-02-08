using Labolatorium_3_v2.Models;
using Data.Entities;

namespace Labolatorium_3_v2.Mappres
{
    public class PostMapper
    {
        public static Post FromEntity(PostEntity entity)
        {
            return new Post()
            {
                Id = entity.PostId,
                Content = entity.Content,
                Autor = entity.Autor,
                Publication_date = entity.Publication_date,
                Tags = entity.Tags,
                Comment = entity.Comment,
                Priority = (Priority)entity.Priority,
                UserId= entity.UserId,
            };
        }

        public static PostEntity ToEntity(Post model)
        {
            return new PostEntity()
            {
                PostId = model.Id,
                Content = model.Content,
                Autor = model.Autor,
                Publication_date = model.Publication_date,
                Tags = model.Tags,
                Comment = model.Comment,
                Priority = (int)model.Priority,
                UserId= model.UserId,
            };
        }
    }
}
