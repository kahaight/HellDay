using HellDay.Data;
using HellDay.Models;
using System;
using System.Collections;
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
        public IEnumerable<PostDetail> GetPosts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Posts.Select(
                            e =>
                                new PostDetail
                                {
                                    Title = e.Title,
                                    Text = e.Text,
                                }
                        );
                return query.ToArray();
            }
        }
        public bool CreatePost(PostCreate model)
        {
            var entity =
                new Post()
                {
                    UserId = model.UserId,
                    Title = model.Title,
                    Text = model.Text
                };
            using (var ctx=new ApplicationDbContext())
            {
                ctx.Posts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
