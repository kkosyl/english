using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace English.Dal.Model
{
    public class PostReplyUserVote
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("PostReply")]
        public int PostReplyId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public bool HasVoted { get; set; }

        public virtual PostReply PostReply { get; set; }
        public virtual User User { get; set; }
    }
}
