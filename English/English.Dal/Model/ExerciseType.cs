using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace English.Dal.Model
{
    public class ExerciseType
    {
        [Key]
        public string Type { get; set; }

        public string Statement { get; set; }
        public string Choices { get; set; }


        public virtual ICollection<Introduction> Introductions { get; set; }
        public virtual ICollection<Exercise> Exercises { get; set; }
    }
}
