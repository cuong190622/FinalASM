using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalASM.Models
{
    public class TraineeEntity
    {
        public TraineeEntity()
        {
            listCourse = new List<CourseEntity>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "Need to input Username")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Need to input Pass")]
        public string Password { get; set; }

        public string Role { get; set; }
        [Required(ErrorMessage = "Need to input name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Need to input Education")]
        public string Education { get; set; }
        [Required(ErrorMessage = "Need to input Age")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Need to input DoB")]
        [DataType(DataType.Date)]
        public DateTime DoB { get; set; }

        public string ProgrammingLanguage { get; set; }
        [Required(ErrorMessage = "Need to input Toeic")]
        public float Toeic { get; set; }

        public string Experience { get; set; }

        public string Department { get; set; }

        public string Location { get; set; }

        public int CourseAssignId { get; set; }

        public List<CourseEntity> listCourse { get; set; }


        public string ToSeparatedString(string separator)
        {
            return $"{this.Id}{separator}" +
                $"{this.Name}{separator}" +
                $"{this.Education}{separator}" +
                $"{this.Age}{separator}" +
                $"{this.DoB}";
        }


    }
}