using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace English.Dal.Model
{
    public class PostReply
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Post")]
        public int PostId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public string Content { get; set; }
        public bool IsUseful { get; set; }
        public DateTime ReplyDate { get; set; }

        public virtual User User { get; set; }
        public virtual Post Post { get; set; }
        public virtual ICollection<PostReplyUserVote> PostReplyUserVotes { get; set; }
    }
}
