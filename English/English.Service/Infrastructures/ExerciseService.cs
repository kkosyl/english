using English.Core.DTO.GET;
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
    public class ExerciseService : IExerciseService
    {
        private IRepository<Exercise> _exercise;
        private IRepository<ExerciseType> _exerciseType;
        private IRepository<UserExercise> _userExercise;
        private IRepository<User> _user;
        private IUnitOfWork _unitOfWork;


        public ExerciseService(IRepository<Exercise> exercise, IRepository<ExerciseType> exerciseType,
            IRepository<User> user, IRepository<UserExercise> userExercise, IUnitOfWork unitOfWork)
        {
            _exercise = exercise;
            _exerciseType = exerciseType;
            _userExercise = userExercise;
            _user = user;
            _unitOfWork = unitOfWork;
        }


        public List<ExerciseTypeDto> GetExerciseTypes(int userId)
        {
            var doneExercises = _userExercise.GetAll().Where(ue => ue.UserId == userId);
            return _exerciseType
                .GetAll()
                .Select(e => new ExerciseTypeDto
            {
                ExerciseType = e.Type,
                Statement = e.Statement,
                ExercisesDone = _exercise
                .GetAll()
                .Where(ex => ex.ExerciseType == e.Type)
                .Count(ex => doneExercises
                    .Any(de => de.ExerciseId == ex.Id))
            }).ToList();
        }


        public ExercisesSetDto GetSetOfExercises(int userId, string type)
        {
            var doneExercises = _userExercise
                .GetAll()
                .Where(ue => ue.UserId == userId)
                .Select(ue => ue.ExerciseId);
            var exercises = _exercise
                .GetAll()
                .Where(e => !doneExercises
                    .Any(d => e.Id == d))
                .Take(10)
                .Select(e => new ExerciseDto
            {
                Content = e.Content,
                Answer = e.Answer
            }).ToList();
            return new ExercisesSetDto
            {
                Statement = _exerciseType.GetAll().First(e => e.Type == type).Statement,
                Exercises = exercises
            };
        }


        public string GetAnswer(int exerciseId)
        {
            return _exercise.Get(exerciseId).Answer;
        }


        public void MarkAsDone(int userId, int exerciseId)
        {
            if (!_userExercise.GetAll().Any(ue => ue.ExerciseId == exerciseId && ue.UserId == userId))
            {
                _userExercise.Add(new UserExercise
                {
                    UserId = userId,
                    ExerciseId = exerciseId
                });
                _unitOfWork.Commit();
            }
        }
    }
}
