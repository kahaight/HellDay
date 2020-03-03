using HellDay.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HellDay.Services
{
    class ReplyService
    {
       
             private readonly int _commentId;
        public ReplyService(int commentId)
        {
            _commentId =commentId;
        }

        public ReplyDetail GetReplyByCommentId(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Comments
                        .Single(e => e.ReplyId == id && e.CommentId == _commentId);
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
