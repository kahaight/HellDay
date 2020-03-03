using HellDay.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HellDay.Services
{
    class PostService
    {
        public IEnumerable GetPost()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Post
                        .Where(e => e.Id == _userId)
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
    }
}
