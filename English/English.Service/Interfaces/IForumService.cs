using English.Core.DTO.GET;
using English.Core.DTO.POST;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace English.Service.Interfaces
{
    public interface IForumService
    {
        List<PostDto> GetTopicList();
        PostDetailsDto GetTopic(int id);

        void AddTopic(NewTopicDto newTopic);
        void AddReply(NewReplyDto newReply);
        void VoteUp(VoteDto vote);
    }
}
