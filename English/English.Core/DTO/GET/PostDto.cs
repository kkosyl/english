using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace English.Core.DTO.GET
{
    public class PostDto
    {
        public int Id { get; set; }
        public string Topic { get; set; }
        public DateTime PostDate { get; set; }
        public string UserOwner { get; set; }
        public DateTime LastActionDate { get; set; }
    }
}
