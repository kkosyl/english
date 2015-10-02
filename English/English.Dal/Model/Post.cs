using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace English.Dal.Model
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public string Topic { get; set; }
        public string Content { get; set; }
        public DateTime DatePosted { get; set; }
        public bool HasNewContent { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<PostReply> PostReplies { get; set; }
    }
}
