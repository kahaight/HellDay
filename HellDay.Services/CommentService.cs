using HellDay.Data;
using HellDay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HellDay.Services
{
    public class CommentService
    {
        private readonly Guid _userId;
        public CommentService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateComment(CommentCreate model)
        {
            var entity = new Comment()
            {
                Text = model.Text,
                UserId = model.UserId,
                PostId = model.PostId
            };
            using(var ctx = new ApplicationDbContext())
            {
                ctx.Comments.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CommentDetail> GetCommentsByPostId(int PostId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Comments
                        .Where(e => e.PostId == PostId)
                        .Select(
                e =>
                    new CommentDetail
                    {
                        Text = e.Text,
                        Author = e.Author.Name,
                        CommentPost = e.CommentPost.Text
                    }
                    );
                return query.ToArray();
            }
        }
    }
}
