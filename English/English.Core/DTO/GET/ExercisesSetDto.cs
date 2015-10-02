using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace English.Core.DTO.GET
{
    public class ExercisesSetDto
    {
        public ExercisesSetDto()
        {
            this.Exercises = new List<ExerciseDto>();
        }

        public string Statement { get; set; }
        public IList<ExerciseDto> Exercises { get; set; }
    }
}
