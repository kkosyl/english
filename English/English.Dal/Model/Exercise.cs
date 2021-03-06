﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace English.Dal.Model
{
    public class Exercise
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Type")]
        public string ExerciseType { get; set; }

        public string Content { get; set; }
        public string Answer { get; set; }

        public virtual ExerciseType Type { get; set; }
        public virtual ICollection<UserExercise> UserExercises { get; set; }
    }
}
