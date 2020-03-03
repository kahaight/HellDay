using HellDay.Data;
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
       
        public IEnumerable GetPost()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Post
                        .Where(e => e.UserId == _userId)
                        .Single(
                            e =>
                                new Post
                                {
                                    Title = e.Title,
                                    Text = e.Text,
                                    Author = e.Author
                                }
                        );

                return query.ToArray();
            }
        }
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
    }
}
