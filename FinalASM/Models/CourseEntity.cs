using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalASM.Models
{
    public class CourseEntity
    {
        public CourseEntity()
        {
            listTrainer = new List<TrainerEntity>();
            listTrainee = new List<TraineeEntity>();
        }
        public List<TraineeEntity> listTrainee { get; set; }
        public CourseCategoryEntity CourseCategory { get; set; }
        public List<TrainerEntity> listTrainer { get; set; }
        public int Id { get; set; }
        [Required(ErrorMessage = "Need to input name")]
        public string Name { get; set; }

        public string Category { get; set; }

        public string Description { get; set; }
    }
}