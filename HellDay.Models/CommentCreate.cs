using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HellDay.Models
{
    class CommentCreate
    {
        //public int Id { get; set; }
        [Required]
        [MinLength(1, ErrorMessage ="Please enter text to comment.")]
        [MaxLength(130, ErrorMessage="Comments are kept to 130 charcters or less.")]
        public string Text { get; set; }
        [Required]
        public User Author { get; set; }
        public Post CommentPost { get; set;}
    }
}
