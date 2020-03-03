using HellDay.Data;
using HellDay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HellDay.Services
{
    public class ReplyService
    {
        private readonly Guid _userId;
        public ReplyService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateReply(ReplyCreate model)
        {
            var entity = new Reply()
            {
                Text = model.Text,
                UserId = _userId,
                PostId = model.PostId,
                CommentId = model.CommentId
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Replies.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public ReplyDetail GetReplyByReplyId(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Replies
                        .Single(e => e.ReplyId == id);
                return
                    new ReplyDetail
                    {
                        ReplyId = entity.ReplyId,
                        Text = entity.Text,
                        Author = entity.Author,
                        ReplyComment = entity.ReplyComment
                    };
            }
        }
    }
}
