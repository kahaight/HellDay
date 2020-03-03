using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HellDay.Data
{
    public class Like
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(LikedPost))]
        public int PostId { get; set; }
        [ForeignKey(nameof(Liker))]
        public Guid UserId { get; set; }
        public virtual Post LikedPost { get; set; }
        public virtual User Liker { get; set; }
    }
}
