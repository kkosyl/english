using English.Core.DTO.GET;
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
    public class IntroductionService : IIntroductionService
    {
        private IRepository<User> _user;
        private IRepository<Introduction> _introduction;


        public IntroductionService(IRepository<User> user, IRepository<Introduction> introduction)
        {
            _user = user;
            _introduction = introduction;
        }


        public List<IntroductionDto> GetIntroductionList()
        {
            return _introduction.GetAll().Select(i => new IntroductionDto
            {
                IntroductionId = i.Id,
                ExerciseType = i.ExerciseType
            }).ToList();
        }

        public IntroductionContentDto GetIntroduction(int id)
        {
            var introduction = _introduction.Get(id);
            return new IntroductionContentDto
            {
                IntroductionId = introduction.Id,
                ExerciseType = introduction.ExerciseType,
                Content = introduction.Content
            };
        }
    }
}
