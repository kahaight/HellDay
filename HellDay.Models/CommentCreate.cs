using HellDay.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HellDay.Models
{
    public class CommentCreate
    {
        public string Text { get; set; }
        public Guid UserId { get; set; }
        public int PostId { get; set; }

    }
}
