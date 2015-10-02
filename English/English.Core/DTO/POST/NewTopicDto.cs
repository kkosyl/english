using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace English.Core.DTO.POST
{
    public class NewTopicDto
    {
        public int UserId { get; set; }
        public string Topic { get; set; }
        public string Content { get; set; }
    }
}
