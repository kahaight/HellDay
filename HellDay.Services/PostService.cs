using HellDay.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HellDay.Services
{
    public class PostService
    {
        private readonly Guid _userId;

        public PostService(Guid userId)
        {
            _userId = userId;
        }
       /* public CommentService(Post postId)
        {
            _
        }*/
        
        public bool PostAPost(PostCreate model)
        {
            var entity =
                new Post()
                {
                    Id = _userId,
                    Title = model.Title,
                    Text = model.Text,
                    Author = model.Author
                };
            using (var ctx=new ApplicationDbContext())
            {
                ctx.Posts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        //Use another service class for Comments?
        
        /*public PostComment GetCommentByPostId(int id)
        {
            using (var ctx=new ApplicationDbContext())
            {
                var entity=
                    ctx
                        .Posts
                        .Single(e=>e.CommentId==id&& e.PostId==)
            }
        }*/

    }
}
