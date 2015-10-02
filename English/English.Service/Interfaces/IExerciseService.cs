using English.Core.DTO.GET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace English.Service.Interfaces
{
    public interface IExerciseService
    {
        List<ExerciseTypeDto> GetExerciseTypes(int userId);
        ExercisesSetDto GetSetOfExercises(int userId, string type);
        string GetAnswer(int exerciseId);

        void MarkAsDone(int userId, int exerciseId);
    }
}
