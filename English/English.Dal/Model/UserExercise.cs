using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace English.Dal.Model
{
    public class UserExercise
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Exercise")]
        public int ExerciseId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public virtual User User { get; set; }
        public virtual Exercise Exercise { get; set; }
    }
}
