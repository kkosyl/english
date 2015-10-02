using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace English.Core.DTO.GET
{
    public class PostReplyDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime ReplyDate { get; set; }
        public int IsUseful { get; set; }
    }
}
