using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HellDay.Services
{
    public class CommentService
    {
        /*private readonly Guid _userId;

        public PostService(Guid userId)
        {
            _userId = userId;
        }*/
        private readonly int _postId;
        public CommentService(int postId)
        {
            _postId = postId;
          }

        public CommentDetail GetCommentByPostId(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Posts
                        .Single(e => e.CommentId == id && e.PostId == _postId);
                return
                    new CommentDetail
                    {
                        CommentId = entity.CommentId,
                        Text = entity.Text,
                        Author = entity.Author,
                        CommentPost = entity.CommentPost
                    };
            }
        }


    }
}
