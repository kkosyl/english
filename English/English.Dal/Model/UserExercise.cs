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

        [ForeignKey("Excercise")]
        public int ExcerciseId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public bool IsDone { get; set; }

        public virtual User User { get; set; }
        public virtual Excercise Excercise { get; set; }
    }
}
