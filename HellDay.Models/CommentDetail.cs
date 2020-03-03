using HellDay.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HellDay.Models
{
    public class CommentDetail
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Author { get; set; }
        public string CommentPost { get; set; }
    }
}
