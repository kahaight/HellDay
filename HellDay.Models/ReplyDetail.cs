using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HellDay.Models
{
    public class ReplyDetail
    {
        public string Text { get; set; }
        public Guid UserId { get; set; }
        public int PostId { get; set; }
    }
}
