using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace English.Dal.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime LastLoginDate { get; set; }

        public virtual ICollection<UserExercise> UserExcercises { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<PostReply> PostReplies { get; set; }
        public virtual ICollection<PostReplyUserVote> PostReplyUserVotes { get; set; }
    }
}
