using English.Core.DTO.GET;
using English.Core.DTO.POST;
using English.Dal;
using English.Dal.Model;
using English.Dal.Repository;
using English.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace English.Service.Infrastructures
{
    public class ForumService : IForumService
    {
        private IRepository<Post> _post;
        private IRepository<PostReply> _postReply;
        private IRepository<PostReplyUserVote> _postReplyUser;
        private IRepository<User> _user;
        private IUnitOfWork _unitOfWork;


        public ForumService(IRepository<Post> post, IRepository<PostReply> postReply, IRepository<PostReplyUserVote> postReplyUser,
            IRepository<User> user, IUnitOfWork unitOfWork)
        {
            _post = post;
            _postReply = postReply;
            _postReplyUser = postReplyUser;
            _unitOfWork = unitOfWork;
            _user = user;
        }


        public List<PostDto> GetTopicList()
        {
            return _post.GetAll().Select(p => new PostDto
            {
                Id = p.Id,
                PostDate = p.DatePosted,
                Topic = p.Topic,
                UserOwner = _user.Get(p.UserId).Login,
                LastActionDate = _postReply
                                .GetAll()
                                .Any(pr => pr.PostId == p.Id) ? _postReply
                                                                .GetAll()
                                                                .Last(pr => pr.PostId == p.Id).ReplyDate : p.DatePosted
            })
            .OrderByDescending(p => p.LastActionDate)
            .ToList();
        }


        public PostDetailsDto GetTopic(int id)
        {
            var post = _post.Get(id);
            PostDetailsDto request = new PostDetailsDto
            {
                Id = post.Id,
                PostDate = post.DatePosted,
                Topic = post.Topic,
                UserOwner = _user.Get(post.UserId).Login
            };
            request.Replies = new List<PostReplyDto>();
            request.Replies = _postReply
                .GetAll()
                .Where(p => p.PostId == id)
                .Select(p => new PostReplyDto
            {
                Id = p.Id,
                Content = p.Content,
                IsUseful = p.Useful,
                ReplyDate = p.ReplyDate
            }).ToList();
            return request;
        }


        public void AddTopic(NewTopicDto newTopic)
        {
            _post.Add(new Post
            {
                Topic = newTopic.Topic,
                Content = newTopic.Content,
                UserId = newTopic.UserId,
                DatePosted = DateTime.Now,
                HasNewContent = false
            });
            _unitOfWork.Commit();
        }


        public void AddReply(NewReplyDto newReply)
        {
            _postReply.Add(new PostReply
            {
                PostId = newReply.PostId,
                UserId = newReply.UserId,
                Content = newReply.Content,
                ReplyDate = DateTime.Now,
                Useful = 0
            });
            _unitOfWork.Commit();
        }


        public void VoteUp(VoteDto vote)
        {
            if (!_postReplyUser.GetAll().Any(p => p.UserId == vote.UserId && p.PostReplyId == vote.ReplyId))
            {
                var reply = _postReply.Get(vote.ReplyId);
                _postReplyUser.Add(new PostReplyUserVote
                {
                    PostReplyId = vote.ReplyId,
                    UserId = vote.UserId
                });
                reply.Useful += 1;
                _postReply.Update(reply);
                _unitOfWork.Commit();
            }
        }
    }
}
